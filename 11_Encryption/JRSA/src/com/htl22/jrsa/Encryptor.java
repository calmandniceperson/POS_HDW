package com.htl22.jrsa;

import javax.crypto.Cipher;
import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import javax.crypto.SealedObject;
import java.io.IOException;
import java.security.InvalidKeyException;
import java.security.KeyPair;
import java.security.KeyPairGenerator;
import java.security.NoSuchAlgorithmException;
import java.security.interfaces.RSAPrivateKey;

/**
 * Created by Michael Koeppl on 12/3/16.
 */
class Encryptor {
    static void encryptRSA(String inputText) throws NoSuchAlgorithmException, NoSuchPaddingException, InvalidKeyException, IOException, IllegalBlockSizeException {
        // Generate public and private key.
        KeyPairGenerator kpg = KeyPairGenerator.getInstance("RSA");
        KeyPair keyPair = kpg.generateKeyPair();

        // Create instance of cipher with RSA and give it the public key to encrypt.
        Cipher cipher = Cipher.getInstance("RSA");
        cipher.init(Cipher.ENCRYPT_MODE, keyPair.getPublic());

        // Encrypt the message using a SealedObject and the cipher.
        SealedObject encryptedMessage = new SealedObject(inputText, cipher);

        System.out.println("Public key: " + new String(keyPair.getPublic().getEncoded(), "UTF-8"));
        RSAPrivateKey privateKey = (RSAPrivateKey) keyPair.getPrivate();
        System.out.println("Private key: \n\tModulus:" + privateKey.getModulus() + "\n\tExponent: " + privateKey.getPrivateExponent());
        System.out.println("Message: " + encryptedMessage);

        // Decrypt
        /*// Get an instance of the Cipher for RSA encryption/decryption
        Cipher dec = Cipher.getInstance("RSA");
        // Initiate the Cipher, telling it that it is going to Decrypt, giving it the private key
        dec.init(Cipher.DECRYPT_MODE, myPair.getPrivate());
        // Tell the SealedObject we created before to decrypt the data and return it
        String message = (String) myEncryptedMessage.getObject(dec);
        System.out.println("foo = "+message);*/
    }
}
