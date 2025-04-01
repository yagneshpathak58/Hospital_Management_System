package com.example.hospitalmain;

import androidx.appcompat.app.AppCompatActivity;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.app.DatePickerDialog;
import android.content.DialogInterface;
import android.content.Intent;
import android.os.Bundle;
import android.os.ConditionVariable;
import android.text.Editable;
import android.text.TextWatcher;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.DatePicker;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.Adapters.CategoryAdapter;
import com.example.hospitalmain.Adapters.OPDAdapter;
import com.example.hospitalmain.Models.CategoryModel;
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.Models.OPDModel;

import org.json.JSONArray;
import org.json.JSONObject;

import java.text.SimpleDateFormat;
import java.time.LocalDate;
import java.time.LocalTime;
import java.util.ArrayList;
import java.util.Calendar;
import java.util.Date;
import java.util.HashMap;
import java.util.Locale;
import java.util.Map;

public class DoctorDetails extends AppCompatActivity {

    Intent intent;
    RecyclerView recyclerViewOPD;
    ArrayList<OPDModel> opdModels;
    OPDAdapter opdAdapter;
    String url_getDoctorByDocid = API.mainAPI + API.getDoctorByDocid;
    String url_getOPdById = API.mainAPI + API.getOPdById;
    String url_AppointmentCount = API.mainAPI + API.AppointmentCount;
    String url_AddAppointment = API.mainAPI + API.AddAppointment;
    TextView tvDrName, tvDrCategory, tvDrRegNo, tvDrFee, tvNoRecord;
    EditText etODate;
    Button btnGetOPD, btnBook;
    final Calendar myCalendar = Calendar.getInstance();
    String myFormat = "MM/dd/yy"; //In which you need put here
    SimpleDateFormat sdf = new SimpleDateFormat(myFormat, Locale.US);
    public String opID = "";
    Map<LocalTime, Boolean> slots = new HashMap();
    SessionManager sess;
    HashMap<String, String> ud;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_doctor_details);

        sess = new SessionManager(getApplicationContext());
        ud = sess.getDetails();

        recyclerViewOPD = findViewById(R.id.recyclerViewOPD);
        opdModels = new ArrayList<>();
        opdAdapter = new OPDAdapter(DoctorDetails.this, opdModels);

        tvNoRecord = findViewById(R.id.tvNoRecord);
        etODate = findViewById(R.id.etODate);
        tvDrName = findViewById(R.id.tvDrName);
        tvDrCategory = findViewById(R.id.tvDrCategory);
        tvDrRegNo = findViewById(R.id.tvDrRegNo);
        tvDrFee = findViewById(R.id.tvDrFee);
        btnGetOPD = findViewById(R.id.btnGetOPD);
        btnBook = findViewById(R.id.btnBook);

        intent = getIntent();
        getDoctorDetails();
        DatePickerDialog.OnDateSetListener date = new DatePickerDialog.OnDateSetListener() {

            @Override
            public void onDateSet(DatePicker view, int year, int monthOfYear,
                                  int dayOfMonth) {
                // TODO Auto-generated method stub
                myCalendar.set(Calendar.YEAR, year);
                myCalendar.set(Calendar.MONTH, monthOfYear);
                myCalendar.set(Calendar.DAY_OF_MONTH, dayOfMonth);
                etODate.setText(sdf.format(myCalendar.getTime()));
            }

        };
        etODate.setOnClickListener(new View.OnClickListener() {

            @Override
            public void onClick(View view) {
                new DatePickerDialog(DoctorDetails.this, date, myCalendar
                        .get(Calendar.YEAR), myCalendar.get(Calendar.MONTH),
                        myCalendar.get(Calendar.DAY_OF_MONTH)).show();


                etODate.setText(sdf.format(myCalendar.getTime()));

            }
        });
        btnGetOPD.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if (etODate.getText().toString().equals("")) {
                    etODate.setError("Please select Date !");
                } else {
                    recyclerViewOPD.setLayoutManager(new GridLayoutManager(DoctorDetails.this, 4));
                    recyclerViewOPD.setAdapter(opdAdapter);
                    HttpsTrustManager.allowAllSSL();
                    getOPD();
                }
            }
        });
        btnBook.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                AppointmentCount();
//                Toast.makeText(DoctorDetails.this, opID, Toast.LENGTH_SHORT).show();
            }
        });
    }

    private void AppointmentCount() {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_AppointmentCount,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            int ac = Integer.parseInt(jsonObject.getString("data"));
                            String firstDate = "26/02/2019";
                            String firstTime = "11:00 AM";
                            String secondDate = "26/02/2019";
                            String secondTime = "02:00 PM";

                            String format = "dd/MM/yyyy hh:mm a";
                            String formatSlot = "hh:mm a";

                            SimpleDateFormat sdf = new SimpleDateFormat(format);

                            Date dateObj1 = sdf.parse(firstDate + " " + firstTime);
                            Date dateObj2 = sdf.parse(secondDate + " " + secondTime);
                            System.out.println("Date Start: " + dateObj1);
                            System.out.println("Date End: " + dateObj2);

                            long dif = dateObj1.getTime();
                            while (dif < dateObj2.getTime()) {
                                Date slot = new Date(dif);
                                SimpleDateFormat sdf1 = new SimpleDateFormat(formatSlot);
                                String sd = sdf.format(slot);
                                System.out.println("Hour Slot --->" + sd);
                                dif += 850000;
                            }
                            bookAppointment();
                        } catch (Exception e) {
                            Toast.makeText(this, "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(this, "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }

            ) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("opid", opID);
                    return param;
                }
            };

            RequestQueue requestQueue = Volley.newRequestQueue(this);
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(this, "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }

    private void bookAppointment() {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_AddAppointment,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);
                            if (jsonObject.getString("data").equals("true")) {
                                Toast.makeText(DoctorDetails.this, "Appointment Booked Successfully..", Toast.LENGTH_SHORT).show();
                            }
                            else
                            {
                                Toast.makeText(DoctorDetails.this, "Something went Wrong.. !", Toast.LENGTH_SHORT).show();
                            }
                            //

                        } catch (Exception e) {
                            Toast.makeText(this, "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(this, "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }

            ) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("opid", opID);
                    param.put("pid", ud.get(SessionManager.KEY_UID));
                    param.put("did", intent.getStringExtra("D_ID"));
                    param.put("opdate", etODate.getText().toString());
                    param.put("optime", "11:42");
                    param.put("dfee", tvDrFee.getText().toString());
                    return param;
                }
            };

            RequestQueue requestQueue = Volley.newRequestQueue(this);
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(this, "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }

    private void getOPD() {
        opdModels.clear();
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getOPdById,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");

                            if (jsonArray.length() <= 0) {
                                tvNoRecord.setVisibility(View.VISIBLE);
                                recyclerViewOPD.setVisibility(View.GONE);
                            } else {
                                tvNoRecord.setVisibility(View.GONE);
                                recyclerViewOPD.setVisibility(View.VISIBLE);
                                for (int i = 0; i < jsonArray.length(); i++) {
                                    JSONObject dataObject = jsonArray.getJSONObject(i);
                                    OPDModel cm = new OPDModel();
                                    cm.setOp_Id(dataObject.getString("Op_Id"));
                                    cm.setOp_Time_From(dataObject.getString("Op_Time_From"));
                                    cm.setOp_Time_To(dataObject.getString("Op_Time_To"));
                                    opdModels.add(cm);
                                }
                            }

                        } catch (Exception e) {
                            Toast.makeText(this, "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }
                        opdAdapter.notifyDataSetChanged();
                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(this, "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("D_Id", intent.getStringExtra("D_ID"));
                    param.put("OPDDate", etODate.getText().toString());
                    return param;
                }
            };


            RequestQueue requestQueue = Volley.newRequestQueue(this);
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(this, "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }

    private void getDoctorDetails() {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getDoctorByDocid,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");

                            for (int i = 0; i < jsonArray.length(); i++) {
                                JSONObject dataObject = jsonArray.getJSONObject(i);
                                tvDrName.setText(dataObject.getString("DR_Name"));
                                tvDrCategory.setText(dataObject.getString("C_Title"));
                                tvDrRegNo.setText(dataObject.getString("DR_Reg_No"));
                                tvDrFee.setText(dataObject.getString("DR_Fee"));
                            }
                        } catch (Exception e) {
                            Toast.makeText(this, "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(this, "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("DR_Id", intent.getStringExtra("D_ID"));
                    return param;
                }
            };


            RequestQueue requestQueue = Volley.newRequestQueue(this);
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(this, "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }
    }
}