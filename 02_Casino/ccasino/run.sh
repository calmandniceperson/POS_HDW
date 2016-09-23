#!/bin/bash
clear
echo "Executing..."
if [[ "$OSTYPE" == "linux-gnu" ]]; then
    FLAGS="-lssl -lcrypto"
elif [[ "$OSTYPE" == "darwin"* ]]; then
    FLAGS="-lcrypto -lssl -I/usr/local/opt/openssl/include -L/usr/local/opt/openssl/lib"
fi
echo "Flags: $FLAGS"
gcc -o casino $FLAGS src/main.c
./casino Spieler1.conf
