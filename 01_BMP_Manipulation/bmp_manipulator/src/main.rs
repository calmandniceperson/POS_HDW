use std::env;
use std::fs::File;
use std::io::Read;
use std::io::Write;

fn manip_bytes(data: &mut Vec<u8>) {
    data[1078] = 0;
}

fn prt_bytes(data: &Vec<u8>) {
    for i in 0..data.len() {
        //let hex = assert_eq!(format!("{:X}", data[i]).as_slice(), "2A");
        //println!("{} ", hex);
        print!("{} ", data[i]);
        if i % 40 == 0 {
            println!("");
        }
    }
}

fn write_f(path: &str, data: &Vec<u8>) {
    let mut f = File::create(path).expect("Unable to create file");
    f.write_all(data).expect("Unable to write data");
}

fn read_f(path: &str, target: &mut Vec<u8>) {
    let mut f = File::open(path).expect("Unable to read file");
    f.read_to_end(target).expect("Unabel to read data");
}

fn main() {
    let args: Vec<_> = env::args().collect();
    if args.len() <= 1 {
        println!("Usage: bmpmanip <path>");
        return;
    }
    let path = &args[1];
    let mut data = Vec::new();
    read_f(&path, &mut data);
    println!("{}", data.len());
    prt_bytes(&data);
    manip_bytes(&mut data);
    write_f("icon1.bmp", &data);
}
