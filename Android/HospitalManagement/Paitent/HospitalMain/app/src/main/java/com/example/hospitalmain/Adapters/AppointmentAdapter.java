package com.example.hospitalmain.Adapters;

import android.content.Context;
import android.content.Intent;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.example.hospitalmain.DoctorDetails;
import com.example.hospitalmain.Models.AppointmentModel;
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.R;

import java.util.ArrayList;

public class AppointmentAdapter extends RecyclerView.Adapter
{
    public Context cntx;
    public ArrayList<AppointmentModel> appItems;

    public AppointmentAdapter(Context cntx, ArrayList<AppointmentModel> appItems)
    {
        this.cntx = cntx;
        this.appItems = appItems;
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {
        RecyclerView.ViewHolder viewHolder;
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_appointment, parent, false);
        viewHolder = new OriginalViewHolder(v);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position)
    {
        if (holder instanceof OriginalViewHolder)
        {
            OriginalViewHolder originalViewHolder =  (OriginalViewHolder) holder;
            AppointmentModel am = appItems.get(position);
            originalViewHolder.tvDocName.setText(am.getP_A_Name());
            originalViewHolder.tvDocCategory.setText(am.getD_ID());
            originalViewHolder.tvopddate.setText(am.getP_A_OPD_Date());
            originalViewHolder.tvopdtime.setText(am.getP_A_OPD_Time()+":00");
            originalViewHolder.Mainlayoutapp.setOnClickListener(new View.OnClickListener()
            {
                @Override
                public void onClick(View view)
                {
                    Bundle bundle = new Bundle();
                    bundle.putString("P_A_Id",am.getP_A_Id());
                    Intent intent = new Intent(cntx, DoctorDetails.class);
                    intent.putExtras(bundle);
                    cntx.startActivity(intent);
                }
            });
        }

    }

    @Override
    public int getItemCount() {
        return appItems.size();
    }

    public class OriginalViewHolder extends RecyclerView.ViewHolder
    {
        TextView tvDocName,tvDocCategory,tvopddate,tvopdtime;
        LinearLayout Mainlayoutapp;

        public OriginalViewHolder(View v)

        {
            super(v);
            tvDocName = v.findViewById(R.id.tvDocName);
            tvDocCategory = v.findViewById(R.id.tvDocCategory);
            tvopddate = v.findViewById(R.id.tvopddate);
            tvopdtime = v.findViewById(R.id.tvopdtime);
            Mainlayoutapp = v.findViewById(R.id.Mainlayoutapp);
        }
    }
}
