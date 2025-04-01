package com.example.hospitalmain;

import android.content.Context;
import android.content.Intent;
import android.content.SharedPreferences;

import java.util.HashMap;

public class SessionManager
{
    SharedPreferences prf;
    SharedPreferences.Editor editor;
    Context _context;
    int PRIVATE_MODE = 0;
    private static final String PREF_NAME = "userdetails";

    private static final String IS_LOGIN = "IsLoggedIn";
    public static final String KEY_NAME = "name";
    public static final String KEY_EMAIL = "email";
    public static final String KEY_UID = "uid";

    public SessionManager(Context context) {
        this._context = context;
        prf = _context.getSharedPreferences(PREF_NAME, PRIVATE_MODE);
        editor = prf.edit();

    }

    public void createLoginSession(String name, String email, String uid) {
        editor.putBoolean(IS_LOGIN, true);
        editor.putString(KEY_NAME, name);
        editor.putString(KEY_EMAIL, email);
        editor.putString(KEY_UID, uid);
        editor.commit();

    }

    public void checkSession() {
        boolean cs = prf.getBoolean(IS_LOGIN, false);
        if (!cs) {
            Intent intent = new Intent(_context, UserSignInActivity.class);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
            intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
            intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
            _context.startActivity(intent);
        }
    }

    public HashMap<String, String> getDetails() {
        HashMap<String, String> ud = new HashMap<>();
        ud.put(KEY_NAME, prf.getString(KEY_NAME, null));
        ud.put(KEY_EMAIL, prf.getString(KEY_EMAIL, null));
        ud.put(KEY_UID, prf.getString(KEY_UID, null));

        return ud;
    }

    public void removeSession()
    {
        editor.clear();
        editor.commit();
        Intent intent = new Intent(_context, UserSignInActivity.class);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TOP);
        intent.addFlags(Intent.FLAG_ACTIVITY_CLEAR_TASK);
        intent.addFlags(Intent.FLAG_ACTIVITY_NEW_TASK);
        _context.startActivity(intent);
    }

    public boolean isLogin() {
        return prf.getBoolean(IS_LOGIN, false);
    }
}
