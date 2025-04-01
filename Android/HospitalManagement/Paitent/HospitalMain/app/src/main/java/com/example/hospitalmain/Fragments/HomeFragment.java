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
import com.example.hospitalmain.Adapters.DoctorAdapter;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.R;
import com.example.hospitalmain.SessionManager;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;


public class HomeFragment extends Fragment {
    View view;
    RecyclerView recyclerViewDoctor;
    ArrayList<DoctorModel> doctorModels;
    DoctorAdapter doctorAdapter;
    TextView tvNoRecord;
    SessionManager sess;
    String url_getTopDoctor = API.mainAPI + API.getTopDoctor;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        view = inflater.inflate(R.layout.fragment_home, container, false);
        tvNoRecord = view.findViewById(R.id.tvNoRecord);
        recyclerViewDoctor = view.findViewById(R.id.recyclerViewDoctor);
        doctorModels = new ArrayList<>();
        doctorAdapter = new DoctorAdapter(getActivity(), doctorModels);
        recyclerViewDoctor.setLayoutManager(new GridLayoutManager(getActivity(), 1));
        recyclerViewDoctor.setAdapter(doctorAdapter);

        HttpsTrustManager.allowAllSSL();
        getTopDoctor();
        return view;
    }

    public void getTopDoctor() {

        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getTopDoctor,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonArray.length() <= 0) {
                                tvNoRecord.setVisibility(View.VISIBLE);
                                recyclerViewDoctor.setVisibility(View.GONE);
                            }
                            else {
                                tvNoRecord.setVisibility(View.GONE);
                                recyclerViewDoctor.setVisibility(View.VISIBLE);
                                for (int i = 0; i < jsonArray.length(); i++) {
                                    JSONObject dataObject = jsonArray.getJSONObject(i);
                                    DoctorModel dm = new DoctorModel();
                                    dm.setDR_Id(dataObject.getString("DR_Id"));
                                    dm.setDR_Name(dataObject.getString("DR_Name"));
                                    dm.setDR_Fee(dataObject.getString("DR_Fee"));
                                    dm.setDR_Date(dataObject.getString("C_Title"));
                                    doctorModels.add(dm);
                                }

                            }
                        } catch (Exception e) {
                            Toast.makeText(getActivity(), "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }
                        doctorAdapter.notifyDataSetChanged();

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(getActivity(), "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    });
            RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(getActivity(), "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }

    }
}