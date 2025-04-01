package com.example.hospitalmain;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.util.Log;
import android.view.View;
import android.widget.Button;
import android.widget.EditText;
import android.widget.TextView;
import android.widget.Toast;

import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.Models.CategoryModel;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.HashMap;
import java.util.Map;

public class UserSignInActivity extends AppCompatActivity {
    SessionManager sess;
    EditText etUName, etPassword;
    TextView tvSignIn, tvSU;
    String url_patientLogin = API.mainAPI + API.patientLogin;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_user_sign_in);

        sess = new SessionManager(getApplicationContext());
        tvSignIn = findViewById(R.id.tvSignIn);
        etUName = findViewById(R.id.etUName);
        etPassword = findViewById(R.id.etPassword);
        tvSU = findViewById(R.id.tvSU);

        tvSignIn.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                if ((etUName.getText().equals("")) || (etPassword.getText().equals("")))
                {
                    if ((etUName.getText().equals(""))) {
                        etUName.setError("Enter Username !");
                    }
                    if ((etPassword.getText().equals(""))) {
                        etPassword.setError("Enter Password !");
                    }
                } else {
                    HttpsTrustManager.allowAllSSL();
                    checkLogin();
                }
            }
        });
        tvSU.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view)
            {
                Intent i = new Intent(getApplicationContext(),UserSignUpActivity.class);
                startActivity(i);

            }
        });

    }

    public void checkLogin()
    {
        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_patientLogin,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

//                            JSONArray jsonArray = jsonObject.getJSONArray("data");
                            if (jsonObject.getString("status").equals("1")) {

                                JSONArray jsonArray = jsonObject.getJSONArray("data");
                                for (int i = 0; i < jsonArray.length(); i++) {
                                    JSONObject dataObject = jsonArray.getJSONObject(i);

//                                    Toast.makeText(this, dataObject.getString("DR_Name"), Toast.LENGTH_SHORT).show();
                                    sess.createLoginSession(dataObject.getString("P_Name"), etUName.getText().toString(), dataObject.getString("P_Id"));
                                    Intent intent = new Intent(getApplicationContext(),MainActivity.class);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
                                    intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
                                    startActivity(intent);
                                }
                            } else {

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
                    param.put("pEmail", etUName.getText().toString());
                    param.put("pPassword", etPassword.getText().toString());
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