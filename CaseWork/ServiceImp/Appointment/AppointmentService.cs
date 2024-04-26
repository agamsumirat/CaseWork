using CaseWork.Model.BodyRequest;
using CaseWork.Model.DTO.Appointment;
using CaseWork.Repository.IAppointmentRepository;
using CaseWork.RepositoryImpl;
using CaseWork.Service.IAppointment;
using CaseWork.Utils.DatabaseHelper;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Transactions;

namespace CaseWork.ServiceImp.Appointment
{
    public class AppointmentService : IAppointmentService
    {
        private readonly DatabaseHelper databaseHelper;

        public AppointmentService(IConfiguration configuration)
        {
            databaseHelper = new (configuration);
        }
       
        IEnumerable<GetAllAppointment> IAppointmentService.GetAllAppointment(DateTime DateAppointment)
        {
            using var sqlConnection = databaseHelper.GetConnection();
            IAppointmentRepository appointmentRepository = new AppointmentRepository(sqlConnection);
            IEnumerable<GetAllAppointment> allAppointment = appointmentRepository.GetAllAppointment(DateAppointment);
            return allAppointment;
        }

        string IAppointmentService.InsertAppointment(AppointmentRequest BodyRequest)
        {
           
                if (BodyRequest.CustomerEmail.Contains(".co.id")==false )
                 {
                     if (BodyRequest.CustomerEmail.Contains(".com") == false)
                    {
                         throw new Exception("Mail format is wrong");
                     }
                 }
                
                if (BodyRequest.CustomerEmail.Contains("@") == false)
                 {
                    throw new Exception("Mail format is wrong, not contain @"); 
                 }
                
                using var transaction = new TransactionScope();

                using var sqlConnection = databaseHelper.GetConnection();

                IAppointmentRepository appointmentRepository = new AppointmentRepository(sqlConnection);


                string token = appointmentRepository.InsertAppointment(BodyRequest);
                transaction.Complete();
                return token;
        }
    }
}
