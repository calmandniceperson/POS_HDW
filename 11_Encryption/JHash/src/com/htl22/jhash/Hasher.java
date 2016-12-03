package com.htl22.jhash;

import java.io.UnsupportedEncodingException;
import java.security.MessageDigest;
import java.security.NoSuchAlgorithmException;

/**
 * Created by Michael Koeppl on 12/3/16.
 */

class Hasher {
    static void hashAll(String text) {
        try {
            System.out.println(new String(hash(text, "MD5"), "UTF-8"));

            System.out.println(new String(hash(text, "SHA-1"), "UTF-8"));
            System.out.println(new String(hash(text, "SHA-256"), "UTF-8"));
            System.out.println(new String(hash(text, "SHA-384"), "UTF-8"));
            System.out.println(new String(hash(text, "SHA-512"), "UTF-8"));
        } catch (UnsupportedEncodingException | NoSuchAlgorithmException e) {
            e.printStackTrace();
        }
    }

    private static byte[] hash(String text, String method) throws NoSuchAlgorithmException {
        byte[] byteText = text.getBytes();
        MessageDigest messageDigest = MessageDigest.getInstance(method);
        return messageDigest.digest(byteText);
    }
}
