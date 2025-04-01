package com.example.hospitalmain.Adapters;

import android.content.Context;
import android.os.Bundle;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.ImageView;
import android.widget.LinearLayout;
import android.widget.TextView;

import androidx.annotation.NonNull;
import androidx.fragment.app.Fragment;
import androidx.fragment.app.FragmentManager;
import androidx.fragment.app.FragmentTransaction;
import androidx.recyclerview.widget.RecyclerView;

import com.bumptech.glide.Glide;
import com.example.hospitalmain.Fragments.DoctorFragment;
import com.example.hospitalmain.MainActivity;
import com.example.hospitalmain.Models.CategoryModel;
import com.example.hospitalmain.R;

import java.util.ArrayList;

public class CategoryAdapter extends RecyclerView.Adapter {

    public Context cntx;
    public ArrayList<CategoryModel> catItems;

    public CategoryAdapter(Context context, ArrayList<CategoryModel> catItem) {
        cntx = context;
        catItems = catItem;
    }


    @NonNull
    @Override
    public RecyclerView.ViewHolder onCreateViewHolder(@NonNull ViewGroup parent, int viewType) {

        RecyclerView.ViewHolder viewHolder;
        View v = LayoutInflater.from(parent.getContext()).inflate(R.layout.item_cat, parent, false);
        viewHolder = new OriginalViewHolder(v);
        return viewHolder;
    }

    @Override
    public void onBindViewHolder(@NonNull RecyclerView.ViewHolder holder, int position)
    {
        if (holder instanceof OriginalViewHolder) {
            OriginalViewHolder originalViewHolder = (OriginalViewHolder) holder;

            CategoryModel cm = catItems.get(position);
            originalViewHolder.tvCatTitle.setText(cm.getC_Title());
//            originalViewHolder.catImage.set
            Glide.with(cntx)
                    .load("https://localhost:44372/CategoryImage/"+cm.getC_Image())
                    .centerCrop()
                    .into(originalViewHolder.catImage);
            originalViewHolder.MainLayoutCat.setOnClickListener(new View.OnClickListener() {
                @Override
                public void onClick(View view) {
                    Bundle bundle = new Bundle();
                    bundle.putString("C_ID", cm.getC_ID());
                    FragmentTransaction ft;
                    Fragment fragment= new DoctorFragment();
                    FragmentManager fragmentManager = ((MainActivity) cntx).getSupportFragmentManager();
                    ft = fragmentManager.beginTransaction();
                    ft.replace(R.id.mainframe, fragment);
                    fragment.setArguments(bundle);
                    ft.commit();

                }
            });
        }

    }

    @Override
    public int getItemCount() {
        return catItems.size();
    }

    public class OriginalViewHolder extends RecyclerView.ViewHolder
    {
        ImageView catImage;
        TextView tvCatTitle;
        LinearLayout MainLayoutCat;

        public OriginalViewHolder(View v) {
            super(v);
            catImage = v.findViewById(R.id.catImage);
            tvCatTitle = v.findViewById(R.id.tvCatTitle);
            MainLayoutCat = v.findViewById(R.id.MainLayoutCat);
        }
    }
}
