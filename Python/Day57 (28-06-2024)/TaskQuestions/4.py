import random

def generate_secret_number():
    return str(random.randint(1000, 9999))

def cow_bull_count(secret, guess):
    cows = bulls = 0
    for i in range(4):
        if guess[i] == secret[i]:
            bulls += 1
        elif guess[i] in secret:
            cows += 1
    return cows, bulls

def play_cow_bull_game():
    secret = generate_secret_number()
    attempts = 0
    print("Welcome to the Cow and Bull Game Presented By Huzair")
    while True:
        guess = input("Enter your guess (4-digit number): ")
        if not guess.isdigit() or len(guess) != 4:
            print("Invalid input. Please enter a 4-digit number.")
            continue
        
        attempts += 1
        cows, bulls = cow_bull_count(secret, guess)
        
        print(f"Cows: {cows}, Bulls: {bulls}")
        
        if bulls == 4:
            print(f"Congratulations! You guessed the number in {attempts} attempts.")
            break

play_cow_bull_game()
