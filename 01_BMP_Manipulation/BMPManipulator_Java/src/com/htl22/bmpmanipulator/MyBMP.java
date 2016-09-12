package com.htl22.bmpmanipulator;

import java.util.ArrayList;

/**
 * Created by Michael Koeppl on 9/12/16.
 */
public class MyBMP {
    private byte[] mBMPHeader;
    private byte[] mBMPInformationBlock;
    private byte[] mBMPData;

    public MyBMP() {
        mBMPHeader = new byte[14];
        mBMPInformationBlock = new byte[40];
    }

    public byte[] getHeader() {
        return mBMPHeader;
    }

    public byte[] getInformationBlock() {
        return mBMPInformationBlock;
    }

    public void setDataLength(int length) {
        mBMPData = new byte[length];
    }

    public byte[] getData() {
        return mBMPData;
    }

    public void manipulateDataByte(int index, byte value) {
        if (index >= mBMPData.length) {
            System.out.println("Index out of range. Data could not be manipulated.");
            return;
        }
        mBMPData[index] = value;
    }

    public byte[] getBytes() {
        int length = mBMPHeader.length + mBMPInformationBlock.length + mBMPData.length;
        ArrayList<Byte> completeList =
                new ArrayList<>(length);
        for (byte b: mBMPHeader) {
            completeList.add(b);
        }
        for (byte b: mBMPInformationBlock) {
            completeList.add(b);
        }
        for (byte b: mBMPData) {
            completeList.add(b);
        }
        byte[] completeByteArray = new byte[length];
        for (int i = 0; i < completeList.size(); ++i) {
            completeByteArray[i] = completeList.get(i);
        }
        return completeByteArray;
    }
}
