package com.example.hospitalmain;

public class API {

    public static String mainAPI = "https://localhost:44372/API/";

    public static String getCategory = "PatientMaster.asmx/getCategory";

    public static String getDoctor = "PatientMaster.asmx/getDoctor";
    public static String getTopDoctor = "PatientMaster.asmx/getTopDoctor";
    public static String patientLogin = "PatientMaster.asmx/PatientLogin";
    public static String getDoctorByCategory = "PatientMaster.asmx/getDoctorByCategory";
    public static String getDoctorByDocid = "PatientMaster.asmx/getDoctorByDocid";
    public static String getOPdById = "DoctorMaster.asmx/getOPdById";
    public static String getAppointment = "PatientMaster.asmx/getAppointment";
    public static String AppointmentCount = "PatientMaster.asmx/AppointmentCount";
    public static String getAppointmentByPatientId = "PatientMaster.asmx/getAppointmentByPatientId";
    public static String getAppointmentById = "PatientMaster.asmx/getAppointmentById";
    public static String AddAppointment = "PatientMaster.asmx/AddAppointment";
//    public static String getPatient = "PatientMaster.asmx/getPatient";
    public static String getPatientByID = "PatientMaster.asmx/getPatientByID";
    public static String getPatientBill = "PatientMaster.asmx/getPatientBill";
    public static String AddPatient = "PatientMaster.asmx/AddPatient";
    public static String AddFeedbackSystem = "PatientMaster.asmx/AddFeedbackSystem";
    public static String AddFeedbackDoctor = "PatientMaster.asmx/AddFeedbackDoctor";
    public static String UpdatePatientProfile = "PatientMaster.asmx/UpdatePatientProfile";
    public static String UpdatePatientPassword = "PatientMaster.asmx/UpdatePatientPassword";
    public static String getFeedBackByUID = "PatientMaster.asmx/getFeedBackByUID";
    public static String getFeedBackByUtype = "PatientMaster.asmx/getFeedBackByUtype";
    public static String getNotificationByUId = "PatientMaster.asmx/getNotificationByUId";
    public static String getNotificationByUtype = "PatientMaster.asmx/getNotificationByUtype";

}
