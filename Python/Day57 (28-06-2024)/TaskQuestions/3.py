def top_players(players):
    sorted_players = sorted(players, key=lambda x: (-x['score'], x['name']))
    return sorted_players[:10]

players = [
    {"name": "Huzair", "score": 99},
    {"name": "Ahmed", "score": 90},
    {"name": "Gokul", "score": 95},
    {"name": "Sanjai", "score": 85},
    {"name": "Ashif", "score": 88},
    {"name": "Noufal", "score": 91},
    {"name": "Aarish", "score": 92},
    {"name": "Anisha", "score": 87},
    {"name": "Riyaz", "score": 93},
    {"name": "Vijay", "score": 89},
    {"name": "Vishal", "score": 94},
    {"name": "Leo", "score": 86}
]

print("Top 10 players:")
for player in top_players(players):
    print(player)
