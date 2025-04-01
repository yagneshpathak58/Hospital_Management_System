package com.example.hospital_management;

import androidx.appcompat.app.AppCompatActivity;

import android.content.Intent;
import android.os.Bundle;
import android.view.View;
import android.widget.TextView;

public class SignInActivity extends AppCompatActivity
{
    TextView tvFP;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_sign_in);
        tvFP = (TextView) findViewById(R.id.tvFP);
        tvFP.setOnClickListener(new View.OnClickListener()
        {
            @Override
            public void onClick(View view)
            {
                Intent i = new Intent(getApplicationContext(),ForgotPasswordActivity.class);
                startActivity(i);

            }
        });
    }
}