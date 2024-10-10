#include <stdio.h>

void wellcome()
{
    // https://patorjk.com/software/taag/#p=display&f=Big&t=Del%20Rev%C3%A9s
    printf("\n");
    printf("  _____       _   _____             __\n");
    printf(" |  __ \\     | | |  __ \\           /_/\n");
    printf(" | |  | | ___| | | |__) |_____   _____  ___\n");
    printf(" | |  | |/ _ \\ | |  _  // _ \\ \\ / / _ \\/ __|\n");
    printf(" | |__| |  __/ | | | \\ \\  __/\\ V /  __/\\__ \\\n");
    printf(" |_____/ \\___|_| |_|  \\_\\___| \\_/ \\___||___/\n");
    printf("\n");
    printf("                                   #nn12ed\n");
    printf("Check the flag:\n");
    printf("> ");
}

bool checker(char* input, int maxLength)
{
    char encryptionKey[25] = { 'T','h','i','s',' ','i','s',' ','a','n',' ','e','n','c','r','y','p','t','i','o','n',' ','k','e','y' };
    for (int i = 0; i < maxLength && input[i] != '\0'; i++)
    {
        input[i] ^= encryptionKey[i % 25];
    }

    // https://gchq.github.io/CyberChef/#recipe=XOR(%7B'option':'UTF8','string':'This%20is%20an%20encryption%20key'%7D,'Standard',false)To_Hex('0x%20with%20comma',0)&input=ZjE0OXt3aDNuXzFuX2QwdTg3X3U1M180X2QzOHU5OTMyfQ&oeol=VT
    char encryptedFlag[34] = { 0x32,0x59,0x5d,0x4a,0x5b,0x1e,0x1b,0x13,0x0f,0x31,0x11,0x0b,0x31,0x07,0x42,0x0c,0x48,0x43,0x36,0x1a,0x5b,0x13,0x34,0x51,0x26,0x30,0x5b,0x51,0x06,0x19,0x50,0x40,0x12,0x1c };
    for (int i = 0; i < 34; i++)
    {
        if (encryptedFlag[i] != input[i])
        {
            return false;
        }
    }
    return true;
}

int main()
{
    wellcome();

    char input[100];
    if (scanf_s("%s", input, 100) != 1)
    {
        printf("This is infuriating! Let's fix this now!\n");
        return 1;
    }

    if (checker(input, 100))
    {
        printf("Amazing! Joy has taken control! The string is perfect\n");
    }
    else
    {
        printf("Oh no... Sadness has taken over. The string is incorrect, let's try again\n");
    }

    scanf_s("%s", input, 100);
    return 0;
}

