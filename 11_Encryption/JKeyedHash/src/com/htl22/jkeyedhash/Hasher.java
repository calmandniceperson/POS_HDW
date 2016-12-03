package com.htl22.jkeyedhash;

import javax.crypto.Mac;
import javax.crypto.spec.SecretKeySpec;
import java.io.UnsupportedEncodingException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;

/**
 * Created by Michael Koeppl on 12/3/16.
 */

 class Hasher {
     static void hashAll(String text, String key) {
         try {
             System.out.println("HmacMD5: " + new String(hash(text, key, "HmacMD5"), "UTF-8"));
             System.out.println("HmacSHA1: " + new String(hash(text, key, "HmacSHA1"), "UTF-8"));
             System.out.println("HmacSHA256: " + new String(hash(text, key, "HmacSHA256"), "UTF-8"));
         } catch (UnsupportedEncodingException | NoSuchAlgorithmException | InvalidKeyException e) {
             e.printStackTrace();
         }
     }

     private static byte[] hash(String text, String key, String method) throws NoSuchAlgorithmException, InvalidKeyException {
         // Get a HmacSHA1/HmacSHA256/HmacMD5 key from the provided key.
         byte[] keyBytes = key.getBytes();
         SecretKeySpec signingKey = new SecretKeySpec(keyBytes, method);

         // Get HmacSHA1/HmacSHA256/HmacMD5 instance and provide key.
         Mac mac = Mac.getInstance(method);
         mac.init(signingKey);

         byte[] byteText = text.getBytes();

         // Compute the hash and return it.
         return mac.doFinal(byteText);
     }
}
