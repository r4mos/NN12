import java.io.IOException;
import java.util.Scanner;

public class Main {
    private static void wellcome() {
        System.out.println();
        System.out.println("  _____       _   _____             __");
        System.out.println(" |  __ \\     | | |  __ \\           /_/");
        System.out.println(" | |  | | ___| | | |__) |_____   _____  ___");
        System.out.println(" | |  | |/ _ \\ | |  _  // _ \\ \\ / / _ \\/ __|");
        System.out.println(" | |__| |  __/ | | | \\ \\  __/\\ V /  __/\\__ \\");
        System.out.println(" |_____/ \\___|_| |_|  \\_\\___| \\_/ \\___||___/");
        System.out.println();
        System.out.println("                                   #nn12ed");
        System.out.println("Check the flag:");
        System.out.print("> ");
    }

    private static boolean checker(byte[] input) {
        byte[] encryptionKey = "This is an encryption key".getBytes();
        for (int i = 0; i < input.length; i++)
        {
            input[i] = (byte)(input[i] ^ encryptionKey[i % encryptionKey.length]);
        }

        // https://gchq.github.io/CyberChef/#recipe=XOR(%7B'option':'UTF8','string':'This%20is%20an%20encryption%20key'%7D,'Standard',false)To_Hex('0x%20with%20comma',0)&input=ZjE0OXt3aDNuXzFuX2QwdTg3X3U1M180X2QzOHU5OTMyfQ&oeol=VT
        byte[] encryptedFlag = { 0x32, 0x59, 0x5d, 0x4a, 0x5b, 0x1e, 0x1b, 0x13, 0x0f, 0x31, 0x11, 0x0b, 0x31, 0x07, 0x42, 0x0c, 0x48, 0x43, 0x36, 0x1a, 0x5b, 0x13, 0x34, 0x51, 0x26, 0x30, 0x5b, 0x51, 0x06, 0x19, 0x50, 0x40, 0x12, 0x1c };
        boolean value = true;
        for (int i = 0; value && i < encryptedFlag.length; i++) {
            if (encryptedFlag[i] != input[i]) {
                value = false;
            }
        }

        return value;
    }

    public static void main(String[] args) throws IOException {
        wellcome();

        Scanner scanner = new Scanner(System.in);
        String input = scanner.nextLine();
        if (input.isEmpty())
        {
            System.out.println("This is infuriating! Let's fix this now!");
            System.exit(1);
        }

        if (checker(input.getBytes()))
        {
            System.out.println("Amazing! Joy has taken control! The string is perfect");
        }
        else
        {
            System.out.println("Oh no... Sadness has taken over. The string is incorrect, let's try again");
        }

        System.in.read();
        System.exit(0);
    }
}