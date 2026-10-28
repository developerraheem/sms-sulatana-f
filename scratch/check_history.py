import json, sys

sys.stdout.reconfigure(encoding='utf-8')
path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\f9011468-650f-4ab1-901b-b8c44e12477d\.system_generated\logs\transcript_full.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'USER_INPUT':
            content = data.get('content', '')
            print("USER_INPUT:\n", content[:1500])
            print("=" * 60)
