import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\634caf60-799c-45a4-8d7f-b9d2dca4e38a\.system_generated\logs\transcript.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'PLANNER_RESPONSE':
            for tc in data.get('tool_calls', []):
                tname = tc.get('name', '')
                if 'file' in tname or 'command' in tname:
                    args = tc.get('args', {})
                    target = args.get('TargetFile', '') or args.get('CommandLine', '')
                    print(tname, "->", str(target)[:120])
