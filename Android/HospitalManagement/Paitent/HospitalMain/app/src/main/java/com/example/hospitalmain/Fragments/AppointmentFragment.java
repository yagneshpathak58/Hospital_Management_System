package com.example.hospitalmain.Fragments;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.API;
import com.example.hospitalmain.Adapters.AppointmentAdapter;
import com.example.hospitalmain.Adapters.DoctorAdapter;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.Models.AppointmentModel;
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.R;
import com.example.hospitalmain.SessionManager;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;


public class AppointmentFragment extends Fragment
{
    View view;
    RecyclerView recyclerViewAppointment;
    ArrayList<AppointmentModel> appointmentModels;
    AppointmentAdapter appointmentAdapter;
    TextView tvNoRecord;
//    SessionManager sess;
    String url_getgetAppointment = API.mainAPI + API.getAppointment;
    SessionManager sess;
    HashMap<String,String> ud;



    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_appointment, container, false);

        sess = new SessionManager(getActivity());
        ud = sess.getDetails();

        tvNoRecord = view.findViewById(R.id.tvNoRecord);
        recyclerViewAppointment = view.findViewById(R.id.recyclerViewAppointment);
        appointmentModels = new ArrayList<>();
        appointmentAdapter = new AppointmentAdapter(getActivity(), appointmentModels);
        recyclerViewAppointment.setLayoutManager(new GridLayoutManager(getActivity(), 1));
        recyclerViewAppointment.setAdapter(appointmentAdapter);

        HttpsTrustManager.allowAllSSL();
        getAppointmentByPatientId();
        return view;
    }

    private void getAppointmentByPatientId()
    {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getgetAppointment,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonArray.length() <= 0) {
                                tvNoRecord.setVisibility(View.VISIBLE);
                                recyclerViewAppointment.setVisibility(View.GONE);
                            }
                            else {
                                tvNoRecord.setVisibility(View.GONE);
                                recyclerViewAppointment.setVisibility(View.VISIBLE);
                                for (int i = 0; i < jsonArray.length(); i++) {
                                    JSONObject dataObject = jsonArray.getJSONObject(i);
                                    AppointmentModel am = new AppointmentModel();
                                    am.setP_ID(dataObject.getString("P_ID"));
                                    am.setP_A_Name(dataObject.getString("DR_Name"));
                                    am.setD_ID(dataObject.getString("DR_Fee"));
                                    am.setP_A_OPD_Date(dataObject.getString("P_A_OPD_Date"));
                                    am.setP_A_OPD_Time(dataObject.getString("P_A_OPD_Time"));
                                    appointmentModels.add(am);
                                }

                            }
                        } catch (Exception e) {
                            Toast.makeText(getActivity(), "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }
                        appointmentAdapter.notifyDataSetChanged();

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(getActivity(), "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }){
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("pid", ud.get(SessionManager.KEY_UID));
                    return param;
                }
            };
            RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(getActivity(), "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }

    }
}