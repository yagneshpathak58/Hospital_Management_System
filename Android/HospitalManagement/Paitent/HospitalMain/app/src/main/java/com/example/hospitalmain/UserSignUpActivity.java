package com.example.hospitalmain;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.EditText;
import android.widget.RadioButton;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class UserSignUpActivity extends AppCompatActivity {
    TextView tvSU, tvSI,tvTC;
    EditText etname, etmobileno, etemailid, etaddress;
    RadioButton rbtnTC;
    SessionManager sess;
    String url_AddPatient = API.mainAPI + API.AddPatient;


    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_sign_up);

        sess = new SessionManager(getApplicationContext());
        tvSI = findViewById(R.id.tvSI);
        etname = findViewById(R.id.etname);
        etmobileno = findViewById(R.id.etmobileno);
        etemailid = findViewById(R.id.etemailid);
        etaddress = findViewById(R.id.etaddress);
        rbtnTC = findViewById(R.id.rbtnTC);
        tvSU = findViewById(R.id.tvSU);
        tvTC = findViewById(R.id.tvTC);
        tvSU.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                if ((etname.getText().toString().equals("")) || (etmobileno.getText().toString().equals("")) || (etemailid.getText().toString().equals("")) || (etaddress.getText().equals("")))
                {
                    if ((etname.getText().toString().equals(""))) {
                        etname.setError("Enter Name !");
                    }
                    if ((etmobileno.getText().toString().equals(""))) {
                        etmobileno.setError("Enter Mobile No !");
                    }
                    if ((etemailid.getText().toString().equals(""))) {
                        etemailid.setError("Enter Email !");
                    }
                    if ((etaddress.getText().toString().equals(""))) {
                        etaddress.setError("Enter Address !");
                    }
                }
                else if (!(rbtnTC.isChecked()))
                {
                    Toast.makeText(UserSignUpActivity.this, "Please accept the Terms & Conditions !!", Toast.LENGTH_SHORT).show();
                }
                else
                    {
                    HttpsTrustManager.allowAllSSL();
                    PatientRegistration();
                }

            }
        });
        tvTC.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                Intent i = new Intent(getApplicationContext(),TermsActivity.class);
                startActivity(i);

            }
        });
    }

    private void PatientRegistration() {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_AddPatient,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

//                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonObject.getString("data").equals("true")) {

//                                etaddress.setText(jsonObject.getString(""));
                                Toast.makeText(this, "Done.", Toast.LENGTH_SHORT).show();
                                Intent i = new Intent(getApplicationContext(), UserSignInActivity.class);
                                startActivity(i);

                            } else {
                                Toast.makeText(this, "Error..", Toast.LENGTH_SHORT).show();
                            }

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
                    param.put("pname", etname.getText().toString());
                    param.put("pcontact", etmobileno.getText().toString());
                    param.put("pemail", etemailid.getText().toString());
                    param.put("paddress", etaddress.getText().toString());
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