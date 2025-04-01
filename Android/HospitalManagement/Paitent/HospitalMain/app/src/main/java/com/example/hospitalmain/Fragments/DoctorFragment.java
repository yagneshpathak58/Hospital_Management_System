package com.example.hospitalmain.Fragments;

import android.os.Bundle;

import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.API;
import com.example.hospitalmain.Adapters.CategoryAdapter;
import com.example.hospitalmain.Adapters.DoctorAdapter;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.Models.CategoryModel;
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.R;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;


public class DoctorFragment extends Fragment {
    View view;
    RecyclerView recyclerViewDoctor;
    ArrayList<DoctorModel> doctorModels;
    DoctorAdapter doctorAdapter;
    String url_getDoctor = API.mainAPI + API.getDoctor;
    String url_getDoctorByCategory = API.mainAPI + API.getDoctorByCategory;
    Bundle bundle;


    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_doctor, container, false);
        bundle = getArguments();
        recyclerViewDoctor = view.findViewById(R.id.recyclerViewDoctor);
        doctorModels = new ArrayList<>();
        doctorAdapter = new DoctorAdapter(getActivity(), doctorModels);
        recyclerViewDoctor.setLayoutManager(new GridLayoutManager(getActivity(), 1));
        recyclerViewDoctor.setAdapter(doctorAdapter);

        HttpsTrustManager.allowAllSSL();
        if (bundle != null) {

            getDoctorByID();
        } else {

            getDoctor();
        }
        return view;
    }

    private void getDoctorByID() {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getDoctorByCategory,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");

                            for (int i = 0; i < jsonArray.length(); i++) {
                                JSONObject dataObject = jsonArray.getJSONObject(i);
                                DoctorModel dm = new DoctorModel();
                                dm.setDR_Id(dataObject.getString("DR_Id"));
                                dm.setDR_Name(dataObject.getString("DR_Name"));
                                dm.setDR_Date(dataObject.getString("DR_Date"));
                                doctorModels.add(dm);
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
                    }) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("C_ID", bundle.getString("C_ID"));
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

    public void getDoctor() {

        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getDoctor,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");

                            for (int i = 0; i < jsonArray.length(); i++) {
                                JSONObject dataObject = jsonArray.getJSONObject(i);
                                DoctorModel dm = new DoctorModel();
                                dm.setDR_Id(dataObject.getString("DR_Id"));
                                dm.setDR_Name(dataObject.getString("DR_Name"));
                                dm.setDR_Date(dataObject.getString("DR_Date"));
                                dm.setDR_Img_Name(dataObject.getString("DR_Img_Name"));
                                doctorModels.add(dm);
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
            /*
            *{
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("C_ID", "");
                    param.put("C_ID", "");
                    param.put("C_ID", "");
                    return param;
                }
            }
            * */
            RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(getActivity(), "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }

    }
}