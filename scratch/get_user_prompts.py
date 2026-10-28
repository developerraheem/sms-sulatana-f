import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\42def0d3-0874-43bc-bbd6-7ec63347fe7f\.system_generated\logs\transcript.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        obj = json.loads(line)
        if obj.get('type') == 'USER_INPUT':
            print("--- STEP", obj.get('step_index'), "---")
            content = obj.get('content', '')
            print(content[:500])
            print("\n")
