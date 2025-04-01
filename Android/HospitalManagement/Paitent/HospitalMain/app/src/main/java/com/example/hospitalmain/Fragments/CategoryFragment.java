package com.example.hospitalmain.Fragments;

import android.os.Bundle;

import androidx.annotation.Nullable;
import androidx.fragment.app.Fragment;
import androidx.recyclerview.widget.GridLayoutManager;
import androidx.recyclerview.widget.RecyclerView;

import android.util.Log;
import android.view.LayoutInflater;
import android.view.View;
import android.view.ViewGroup;
import android.widget.Toast;

import com.android.volley.AuthFailureError;
import com.android.volley.Request;
import com.android.volley.RequestQueue;
import com.android.volley.toolbox.StringRequest;
import com.android.volley.toolbox.Volley;
import com.example.hospitalmain.API;
import com.example.hospitalmain.Adapters.CategoryAdapter;
import com.example.hospitalmain.HttpsTrustManager;
import com.example.hospitalmain.Models.CategoryModel;
import com.example.hospitalmain.R;

import org.json.JSONArray;
import org.json.JSONObject;

import java.util.ArrayList;
import java.util.HashMap;
import java.util.Map;


public class CategoryFragment extends Fragment {

    View view;
    RecyclerView recyclerViewCategory;
    ArrayList<CategoryModel> categoryModels;
    CategoryAdapter categoryAdapter;
    String url_getCategory = API.mainAPI + API.getCategory;

    @Override
    public void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);

    }

    @Override
    public View onCreateView(LayoutInflater inflater, ViewGroup container,
                             Bundle savedInstanceState) {
        // Inflate the layout for this fragment
        view = inflater.inflate(R.layout.fragment_category, container, false);

        recyclerViewCategory = view.findViewById(R.id.recyclerViewCategory);
        categoryModels = new ArrayList<>();
        categoryAdapter = new CategoryAdapter(getActivity(), categoryModels);

        recyclerViewCategory.setLayoutManager(new GridLayoutManager(getActivity(), 3));
        recyclerViewCategory.setAdapter(categoryAdapter);

        HttpsTrustManager.allowAllSSL();
        getCategory();

        return view;
    }

    public void getCategory()
    {

        try {
            StringRequest stringRequest = new StringRequest(Request.Method.POST, url_getCategory,
                    response -> {
                        try {
                            Log.i("Response:", response);
                            JSONObject jsonObject = new JSONObject(response);

                            JSONArray jsonArray = jsonObject.getJSONArray("data");

                            for (int i = 0; i < jsonArray.length(); i++) {
                                JSONObject dataObject = jsonArray.getJSONObject(i);
                                CategoryModel cm = new CategoryModel();
                                cm.setC_ID(dataObject.getString("C_ID"));
                                cm.setC_Title(dataObject.getString("C_Title"));
                                cm.setC_Image(dataObject.getString("C_Image"));
                                categoryModels.add(cm);
                            }
                        } catch (Exception e) {
                            Toast.makeText(getActivity(), "1_" + e.getMessage(), Toast.LENGTH_SHORT).show();
                            e.printStackTrace();
                        }
                        categoryAdapter.notifyDataSetChanged();

                    },
                    error -> {
                        Log.e("ERROR:", error.getMessage());
                        Toast.makeText(getActivity(), "2_" + error.getMessage(), Toast.LENGTH_SHORT).show();
                    });
            /*
            *{
                @Override
                protected Map<String, String> getParams() {
                    Map<String, String> param = new HashMap<String, String>();
                    param.put("C_ID", "");
                    param.put("C_ID", "");
                    param.put("C_ID", "");
                    return param;
                }
            }
            * */
            RequestQueue requestQueue = Volley.newRequestQueue(getActivity());
            requestQueue.add(stringRequest);

        } catch (Exception e) {
            Toast.makeText(getActivity(), "3_" + e.getMessage(), Toast.LENGTH_SHORT).show();
            e.printStackTrace();
        }

    }
}