package com.example.hospitalmain.Adapters;

import android.annotation.SuppressLint;
import android.content.Context;
import android.os.Bundle;
import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;
import android.widget.Toast;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.example.hospitalmain.DoctorDetails;
import com.example.hospitalmain.Fragments.DoctorFragment;
import com.example.hospitalmain.MainActivity;
import com.example.hospitalmain.Models.OPDModel;
import com.example.hospitalmain.Models.OPDModel;
import com.example.hospitalmain.R;

import java.util.ArrayList;

public class OPDAdapter extends RecyclerView.Adapter {

    public Context cntx;
    public ArrayList<OPDModel> catItems;
    public int row_index = -1;

    public OPDAdapter(Context context, ArrayList<OPDModel> catItem) {
        cntx = context;
        catItems = catItem;
    }


    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        RecyclerView.ViewHolder viewHolder;
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_opd, parent, false);
        viewHolder = new OriginalViewHolder(v);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position) {
        if (holder instanceof OriginalViewHolder) {
            OriginalViewHolder originalViewHolder = (OriginalViewHolder) holder;
            int p = position;

            OPDModel cm = catItems.get(position);
            originalViewHolder.tvOPD.setText(cm.getOp_Time_From() + " - " + cm.getOp_Time_To());
            originalViewHolder.tvOPD.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    row_index = p;
                    notifyDataSetChanged();
                }
            });
            if (row_index == p) {
                OPDModel opdModel = catItems.get(p);
                ((DoctorDetails) cntx).opID = opdModel.getOp_Id();
                originalViewHolder.tvOPD.setBackgroundColor(cntx.getResources().getColor(R.color.colorPrimary));
                originalViewHolder.tvOPD.setTextColor(cntx.getResources().getColor(R.color.white));
            } else {
                originalViewHolder.tvOPD.setBackgroundColor(cntx.getResources().getColor(R.color.white));
                originalViewHolder.tvOPD.setTextColor(cntx.getResources().getColor(R.color.grey));
            }
        }

    }

    @Override
    public int getItemCount() {
        return catItems.size();
    }

    public class OriginalViewHolder extends RecyclerView.ViewHolder {
        TextView tvOPD;

        public OriginalViewHolder(View v) {
            super(v);
            tvOPD = v.findViewById(R.id.tvOPD);
        }
    }
}
