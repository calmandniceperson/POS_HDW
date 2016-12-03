package com.htl22.jhash;

import java.util.Scanner;

public class Main {

    public static void main(String[] args) {
        // Get input string
	    System.out.print("Enter your text: ");
	    Scanner scan = new Scanner(System.in);
	    String inputString = scan.nextLine();

	    // Hashes the string using MD5, SHA-1, SHA-256, SHA-384, and SHA-512 and prints all versions.
        Hasher.hashAll(inputString);
    }
}
