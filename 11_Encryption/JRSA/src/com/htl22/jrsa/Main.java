package com.htl22.jrsa;

import javax.crypto.IllegalBlockSizeException;
import javax.crypto.NoSuchPaddingException;
import java.io.IOException;
import java.security.InvalidKeyException;
import java.security.NoSuchAlgorithmException;
import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        System.out.print("Enter your text: ");
        Scanner scan = new Scanner(System.in);
        String inputText = scan.nextLine();
        try {
            Encryptor.encryptRSA(inputText);
        } catch (NoSuchAlgorithmException | NoSuchPaddingException | InvalidKeyException | IOException | IllegalBlockSizeException e) {
            e.printStackTrace();
        }
    }
}
