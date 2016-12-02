package com.htl22.jdes;

import javax.crypto.*;
import javax.crypto.spec.DESKeySpec;
import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.security.spec.InvalidKeySpecException;

/**
 * Created by Michael Koeppl on 12/2/16.
 */
class DES {

    private static final String STANDARD = "DES";

    static void encrypt(String key, String filePath) throws IOException {

        // Check if the given source exists and is a file.
        File sourceFile = new File(filePath);
        if (!fileExists(sourceFile)) {
            throw new IOException("File does not exist");
        }

        try {
            System.out.println("Starting to encrypt...");

            // Generate key.
            DESKeySpec keySpec = new DESKeySpec(key.getBytes());
            SecretKeyFactory keyFactory = SecretKeyFactory.getInstance(STANDARD);
            SecretKey sKey = keyFactory.generateSecret(keySpec);

            // Generate cipher.
            Cipher cipher = Cipher.getInstance(STANDARD);
            cipher.init(Cipher.ENCRYPT_MODE, sKey);

            // Get file text
            byte[] plainText = Files.readAllBytes(Paths.get(filePath));

            // Write to file with cipher stream.
            FileOutputStream outStream = new FileOutputStream(sourceFile, false);
            CipherOutputStream cOutStream = new CipherOutputStream(outStream, cipher);
            cOutStream.write(plainText);
            cOutStream.flush();
            cOutStream.close();

            System.out.println("Done encrypting!");

        } catch (InvalidKeyException | NoSuchAlgorithmException | InvalidKeySpecException | NoSuchPaddingException e) {
            e.printStackTrace();
        }
    }

    static void decrypt(String key, String filePath) throws IOException {
        // Check if file exists
        File sourceFile = new File(filePath);
        if (!fileExists(sourceFile)) {
            throw new IOException("File does not exist.");
        }

        try {
            System.out.println("Starting to decrypt...");

            // Generate key.
            DESKeySpec keySpec = new DESKeySpec(key.getBytes());
            SecretKeyFactory keyFactory = SecretKeyFactory.getInstance(STANDARD);
            SecretKey sKey = keyFactory.generateSecret(keySpec);

            // Generate cipher.
            Cipher cipher = Cipher.getInstance(STANDARD);
            cipher.init(Cipher.DECRYPT_MODE, sKey);

            // Get file text
            CipherInputStream cInStream = new CipherInputStream(new FileInputStream(sourceFile), cipher);
            byte[] plainText = new byte[1024];
            int readBytes = cInStream.read(plainText);
            System.out.println(String.format("Read bytes: %d", readBytes));

            // Write plain text to file.
            FileOutputStream outStream = new FileOutputStream(sourceFile, false);
            outStream.write(plainText);
            outStream.flush();
            outStream.close();

            System.out.println("Done decrypting!");

        } catch (InvalidKeyException | NoSuchPaddingException | NoSuchAlgorithmException | InvalidKeySpecException e) {
            e.printStackTrace();
        }
    }

    private static boolean fileExists(File sourceFile) {
        return sourceFile.exists() && !sourceFile.isDirectory();
    }
}
