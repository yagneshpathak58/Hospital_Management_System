package com.example.hospitalmain.Fragments;

import static com.example.hospitalmain.API.UpdatePatientProfile;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.API;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.R;
import com.example.hospitalmain.SessionManager;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;


public class ProfileFragment extends Fragment
{
    View view;
    EditText etname,etmob, etemail,etaddress;
    Button btnupprofile;
    LinearLayout lbtnup;
    String url_UpdatePatientProfile = API.mainAPI + UpdatePatientProfile;
    String url_getPatientByID = API.mainAPI + API.getPatientByID;
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
        view = inflater.inflate(R.layout.fragment_profile, container, false);

        sess = new SessionManager(getActivity());
        ud = sess.getDetails();

        etname = view.findViewById(R.id.etname);
        etmob = view.findViewById(R.id.etmob);
        etemail = view.findViewById(R.id.etemail);
        etaddress = view.findViewById(R.id.etaddress);
        lbtnup = view.findViewById(R.id.lbtnup);
        btnupprofile = view.findViewById(R.id.btnupprofile);


        HttpsTrustManager.allowAllSSL();
        getPatientByID();

        btnupprofile.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                UpdatePatientProfile();
            }
        });


        return view;
    }

    private void UpdatePatientProfile()
    {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_UpdatePatientProfile,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

//                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonObject.getString("data").equals("true")) {
                                Toast.makeText(getActivity(), "Saved Successfully.", Toast.LENGTH_SHORT).show();

                            }

                        } catch (Exception e) {
                            Toast.makeText(getActivity(), "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(getActivity(), "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }

            ) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("pid", ud.get(SessionManager.KEY_UID));
                    param.put("pname", etname.getText().toString()); //11/19/2021 mm/dd/yyyy
                    param.put("pcontact", etmob.getText().toString());
                    param.put("paddress", etaddress.getText().toString());
//                    param.put("OpdTimeTo", etOTimeTo.getText().toString());
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


    private void getPatientByID()
    {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getPatientByID,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");
//                            if (jsonObject.getString("data").equals("true")) {
//                                Toast.makeText(getActivity(), "Added Successfully.", Toast.LENGTH_SHORT).show();
                            for (int i = 0; i < jsonArray.length(); i++)
                            {
                                JSONObject dataObject = jsonArray.getJSONObject(i);
//                                    CategoryModel cm = new CategoryModel();
                                etname.setText(dataObject.getString("P_Name"));
                                etmob.setText(dataObject.getString("P_Contact"));
                                etemail.setText(dataObject.getString("P_Email"));
                                etaddress.setText(dataObject.getString("P_Address"));

//                                    categoryModels.add(cm);
                            }

                        } catch (Exception e) {
                            Toast.makeText(getActivity(), "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(getActivity(), "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    }

            ) {
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("P_Id", ud.get(SessionManager.KEY_UID));
//                    param.put("OpdDate", etODate.getText().toString()); //11/19/2021 mm/dd/yyyy
//                    param.put("OpdTimeFrom", etOTimeFrom.getText().toString());
//                    param.put("OpdTimeTo", etOTimeTo.getText().toString());
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