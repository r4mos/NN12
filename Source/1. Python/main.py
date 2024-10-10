def welcome():
    print()
    print("  _____       _   _____             __")
    print(" |  __ \\     | | |  __ \\           /_/")
    print(" | |  | | ___| | | |__) |_____   _____  ___")
    print(" | |  | |/ _ \\ | |  _  // _ \\ \\ / / _ \\/ __|")
    print(" | |__| |  __/ | | | \\ \\  __/\\ V /  __/\\__ \\")
    print(" |_____/ \\___|_| |_|  \\_\\___| \\_/ \\___||___/")
    print()
    print("                                   #nn12ed")
    print("Check the flag:")
    print("> ", end='')


def checker(input_bytes):
    encryption_key = b"This is an encryption key"
    for i in range(len(input_bytes)):
        input_bytes[i] ^= encryption_key[i % len(encryption_key)]

    encrypted_flag = bytearray([
        0x32, 0x59, 0x5d, 0x4a, 0x5b, 0x1e, 0x1b, 0x13, 0x0f, 0x31, 0x11, 0x0b,
        0x31, 0x07, 0x42, 0x0c, 0x48, 0x43, 0x36, 0x1a, 0x5b, 0x13, 0x34, 0x51,
        0x26, 0x30, 0x5b, 0x51, 0x06, 0x19, 0x50, 0x40, 0x12, 0x1c
    ])
    return encrypted_flag == input_bytes


def main():
    welcome()

    user_input = input()
    if not user_input:
        print("This is infuriating! Let's fix this now!")
        return 1

    if checker(bytearray(user_input.encode('utf-8'))):
        print("Amazing! Joy has taken control! The string is perfect")
    else:
        print("Oh no... Sadness has taken over. The string is incorrect, let's try again")

    input()
    return 0


if __name__ == "__main__":
    exit(main())
