package com.htl22.bmpmanipulator;

import java.io.File;
import java.io.FileInputStream;
import java.io.FileOutputStream;
import java.io.IOException;

public class Main {

    /**
     * Usage string displayed to the user
     */
    private final static String USAGE_STRING = "Usage: BMPManipulator <file path>";

    /**
     * Number of images to be created
     */
    private final static int NUM_OF_IMAGES = 10;

    /**
     * Input and Output file
     */
    private static File mInFile, mOutFile;

    /**
     * In- and Output stream
     */
    private static FileInputStream mFileInputStream;
    private static FileOutputStream mFileOutputStream;

    public static void main(String[] args) {

        /*
          Check whether there are enough arguments
         */
        if (args.length < 1) {
            System.out.println(USAGE_STRING);
            return;
        }

        /*
          Create directory if it doesn't exist
         */
        File bitmapsDir = new File("bitmaps/");
        if (!bitmapsDir.exists() || !bitmapsDir.isDirectory()) {
            bitmapsDir.mkdirs();
        }

        mInFile = new File(args[0]);
        craftNewImage();
    }

    private static void craftNewImage() {
        /*
          Run through the whole process for every image
         */
        for (int i = 0; i < NUM_OF_IMAGES; ++i) {
            try {
                MyBMP bmp  = readTargetBMP(i);
                for (int j = 0; j < bmp.getBytes().length/6; ++j) {
                    bmp.manipulateDataByte(j, Byte.parseByte(""+-128));
                }
                mFileOutputStream = new FileOutputStream(new File("bitmaps/bitmap"+i+".bmp"));
                mFileOutputStream.write(bmp.getBytes());
                mFileOutputStream.close();
            } catch (IOException e) {
                e.printStackTrace();
            }
        }
    }

    private static MyBMP readTargetBMP(int i) throws IOException {
        mFileInputStream = new FileInputStream(mInFile);
        MyBMP bmp = new MyBMP();
        mFileInputStream.read(bmp.getHeader());
        mFileInputStream.read(bmp.getInformationBlock());
        bmp.setDataLength(mFileInputStream.available());
        mFileInputStream.read(bmp.getData());
        System.out.println("Image Nr. " + i);
        for (byte b: bmp.getHeader()) {
            System.out.print(Integer.toHexString(b) + " ");
        }
        System.out.println();
        for (byte b: bmp.getInformationBlock()) {
            System.out.print(Integer.toHexString(b) + " ");
        }
        System.out.println();
        for (byte b: bmp.getData()) {
            System.out.print(Integer.toHexString(b) + " ");
        }
        System.out.println("\n");
        mFileInputStream.close();
        return bmp;
    }
}
