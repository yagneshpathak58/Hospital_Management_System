package com.example.hospitalmain.Fragments;

import android.os.Bundle;

import androidx.fragment.app.Fragment;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.API;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.R;
import com.example.hospitalmain.SessionManager;

import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;


public class ChangePasswordFragment extends Fragment
{
    View view;
    SessionManager sess;
    HashMap<String, String> ud;
    EditText etOldPassword, etNewPassword, etConfirmPassword;
    Button btnupdate;
    String url_UpdatePatientPassword = API.mainAPI + API.UpdatePatientPassword;





    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_change_password, container, false);
        sess = new SessionManager(getActivity());
        ud = sess.getDetails();
        btnupdate = view.findViewById(R.id.btnupdate);
        etOldPassword = view.findViewById(R.id.etOldPassword);
        etNewPassword = view.findViewById(R.id.etNewPassword);
        etConfirmPassword = view.findViewById(R.id.etConfirmPassword);


        btnupdate.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View v) {
                if ((etOldPassword.getText().equals("")) || (etNewPassword.getText().equals("")) || (etConfirmPassword.getText().equals(""))) {
                    if ((etOldPassword.getText().equals(""))) {
                        etOldPassword.setError("Enter Old Password !");
                    }
                    if ((etNewPassword.getText().equals(""))) {
                        etNewPassword.setError("Enter New Password !");
                    }
                    if ((etConfirmPassword.getText().equals(""))) {
                        etConfirmPassword.setError("Enter Confirm Password !");
                    }
                } else if (!(etNewPassword.getText().toString().equals(etConfirmPassword.getText().toString()))) {
                    etConfirmPassword.setError("New passwords didn't match.!!");
                } else {
                    HttpsTrustManager.allowAllSSL();
                    updatePassword();
                }
            }
        });

        return view;
    }

    private void updatePassword()
    {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_UpdatePatientPassword,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

//                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonObject.getString("data").equals("true")) {
                                Toast.makeText(getActivity(), "Password changed Successfully.", Toast.LENGTH_SHORT).show();
                                etOldPassword.setText("");
                                etNewPassword.setText("");
                                etConfirmPassword.setText("");

                            } else {
                                Toast.makeText(getActivity(), "Old password doesn't match.!!", Toast.LENGTH_SHORT).show();
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
                    param.put("patPasswordOld", etOldPassword.getText().toString());
                    param.put("patPassword", etNewPassword.getText().toString());
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