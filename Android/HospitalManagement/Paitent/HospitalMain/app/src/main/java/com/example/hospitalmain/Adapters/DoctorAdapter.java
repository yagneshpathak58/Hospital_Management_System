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
import com.example.hospitalmain.Models.DoctorModel;
import com.example.hospitalmain.R;

import java.util.ArrayList;

public class DoctorAdapter extends RecyclerView.Adapter
{
    public Context cntx;
    public ArrayList<DoctorModel> docItems;

    public DoctorAdapter(Context cntx, ArrayList<DoctorModel> docItems) {
        this.cntx = cntx;
        this.docItems = docItems;
    }

    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType)
    {
        RecyclerView.ViewHolder viewHolder;
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_doctor, parent, false);
        viewHolder = new OriginalViewHolder(v);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position)
    {
        if (holder instanceof OriginalViewHolder)
        {
            OriginalViewHolder originalViewHolder =  (OriginalViewHolder) holder;
            DoctorModel dm = docItems.get(position);
            originalViewHolder.tvDocName.setText(dm.getDR_Name());
            originalViewHolder.tvDocCategory.setText(dm.getDR_Date());
            originalViewHolder.tvDocFee.setText(dm.getDR_Fee());
            Glide.with(cntx)
                    .load("https://localhost:44372/DoctorImage/"+dm.getDR_Img_Name())
                    .centerCrop()
                    .into(originalViewHolder.ivDr);
            originalViewHolder.MainLayoutDoc.setOnClickListener(new View.OnClickListener()
            {
                @Override
                public void onClick(View view)
                {
                    Bundle bundle = new Bundle();
                    bundle.putString("D_ID",dm.getDR_Id());
                    Intent intent = new Intent(cntx, DoctorDetails.class);
                    intent.putExtras(bundle);
                    cntx.startActivity(intent);
                }
            });
        }

    }

    @Override
    public int getItemCount() {
        return docItems.size();
    }

    public class OriginalViewHolder extends RecyclerView.ViewHolder
    {
        TextView tvDocName,tvDocCategory,tvDocFee;
        LinearLayout MainLayoutDoc;
        ImageView ivDr;
        public OriginalViewHolder(View v)

        {
            super(v);
            tvDocName = v.findViewById(R.id.tvDocName);
            tvDocCategory = v.findViewById(R.id.tvDocCategory);
            tvDocFee = v.findViewById(R.id.tvDocFee);
            ivDr = v.findViewById(R.id.ivDr);
            MainLayoutDoc = v.findViewById(R.id.MainLayoutDoc);
        }
    }
}
