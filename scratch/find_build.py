import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\e2dbacc9-f84f-4b6b-aabe-37d16df0902d\.system_generated\logs\transcript_full.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'PLANNER_RESPONSE':
            for tc in data.get('tool_calls', []):
                if tc.get('name') == 'run_command':
                    cmd = tc.get('args', {}).get('CommandLine', '')
                    if 'build' in cmd or 'csc' in cmd or 'sln' in cmd or 'csproj' in cmd or 'Compile' in cmd:
                        print("CMD:", cmd)
