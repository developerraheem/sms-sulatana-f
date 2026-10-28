import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\98f272db-011c-49fe-ac21-f35c4b6bc611\.system_generated\logs\transcript_full.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'PLANNER_RESPONSE':
            for tc in data.get('tool_calls', []):
                args = tc.get('args', {})
                if 'Implement auto-loading' in str(args.get('Description', '')):
                    chunks = args.get('ReplacementChunks', [])
                    print("--- CHUNK 1 TARGET ---")
                    print(chunks[0].get('TargetContent'))
                    print("--- CHUNK 1 REPLACEMENT (first 1000 chars) ---")
                    print(chunks[0].get('ReplacementContent')[:1000])
