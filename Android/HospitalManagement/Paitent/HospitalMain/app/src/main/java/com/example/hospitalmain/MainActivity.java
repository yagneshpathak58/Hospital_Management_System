package com.example.hospitalmain;

import android.graphics.Color;
import android.os.Bundle;
import android.view.MenuItem;
import android.view.View;
import android.widget.TextView;
import android.widget.Toast;

import com.example.hospitalmain.Fragments.AppointmentFragment;
import com.example.hospitalmain.Fragments.BillFragment;
import com.example.hospitalmain.Fragments.CategoryFragment;
import com.example.hospitalmain.Fragments.ChangePasswordFragment;
import com.example.hospitalmain.Fragments.DoctorFragment;
import com.example.hospitalmain.Fragments.GiveFeedbackFragment;
import com.example.hospitalmain.Fragments.HelpFragment;
import com.example.hospitalmain.Fragments.HomeFragment;
import com.example.hospitalmain.Fragments.NotificationFragment;
import com.example.hospitalmain.Fragments.ProfileFragment;
import com.example.hospitalmain.databinding.ActivityMainBinding;
import com.google.android.material.navigation.NavigationView;

import androidx.annotation.NonNull;
import androidx.appcompat.app.ActionBarDrawerToggle;
import androidx.appcompat.widget.Toolbar;
import androidx.core.view.GravityCompat;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentTransaction;
import androidx.navigation.ui.AppBarConfiguration;
import androidx.drawerlayout.widget.DrawerLayout;
import androidx.appcompat.app.AppCompatActivity;


import java.util.HashMap;

public class MainActivity extends AppCompatActivity implements NavigationView.OnNavigationItemSelectedListener
{
    DrawerLayout drawer;
    FragmentTransaction ft;
    private AppBarConfiguration mAppBarConfiguration;
    private ActivityMainBinding binding;
    SessionManager sess;
    HashMap<String, String> ud;

    TextView tvpName, tvpEmail;

    @Override
    protected void onCreate(Bundle savedInstanceState)
    {
        super.onCreate(savedInstanceState);

        sess = new SessionManager(getApplicationContext());
        ud = sess.getDetails();

        binding = ActivityMainBinding.inflate(getLayoutInflater());
        setContentView(binding.getRoot());
        Toolbar toolbar = findViewById(R.id.toolbar);
        toolbar.setTitleTextColor(Color.WHITE);
        setSupportActionBar(toolbar);

        drawer = binding.drawerLayout;
        NavigationView navigationView = binding.navView;
        View headerView = navigationView.getHeaderView(0);
        tvpName = headerView.findViewById(R.id.tvpName);
        tvpEmail = headerView.findViewById(R.id.tvpEmail);

        tvpName.setText(ud.get(SessionManager.KEY_NAME));
        tvpEmail.setText(ud.get(SessionManager.KEY_EMAIL));

        ActionBarDrawerToggle toggle = new ActionBarDrawerToggle(this,drawer,toolbar,0,0)
        {
            public void onDrawerOpened(View dv)
            {
                super.onDrawerOpened(dv);
            }
        };
        drawer.setDrawerListener(toggle);
        toggle.syncState();
        // Passing each menu ID as a set of Ids because each
        // menu should be considered as top level destinations.
        navigationView.setNavigationItemSelectedListener(this);
        changeFgmt(new HomeFragment());
    }

    @Override
    public boolean onNavigationItemSelected(@NonNull MenuItem item)
    {
        int menuitem = item.getItemId();
        switch (menuitem)
        {
            case R.id.nav_home:
                changeFgmt(new HomeFragment());
                Toast.makeText(this, "Home", Toast.LENGTH_SHORT).show();

                break;
            case R.id.nav_profile:
                changeFgmt(new ProfileFragment());

                Toast.makeText(this, "Profile", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_changepass:
                changeFgmt(new ChangePasswordFragment());

                Toast.makeText(this, "Change Password", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_category:
                changeFgmt(new CategoryFragment());

                Toast.makeText(this, "Category", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_doctor:
                changeFgmt(new DoctorFragment());

                Toast.makeText(this, "Doctor", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_appointment:
                changeFgmt(new AppointmentFragment());
                Toast.makeText(this, "Appointment", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_bill:
                changeFgmt(new BillFragment());
                Toast.makeText(this, "Bill", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_notification:
                changeFgmt(new NotificationFragment());
                Toast.makeText(this, "Notification", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_givefeedback:
                changeFgmt(new GiveFeedbackFragment());
                Toast.makeText(this, "Give Feedback", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_help:
                changeFgmt(new HelpFragment());
                Toast.makeText(this, "Help", Toast.LENGTH_SHORT).show();
                break;
            case R.id.nav_logout:
                sess.removeSession();
        }
        return true;
    }

    public void changeFgmt(Fragment fragment)
    {
        drawer.closeDrawer(GravityCompat.START);
        ft = getSupportFragmentManager().beginTransaction();
        ft.replace(R.id.mainframe, fragment);
        ft.commit();
    }
}