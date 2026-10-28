import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\98f272db-011c-49fe-ac21-f35c4b6bc611\.system_generated\logs\transcript.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'PLANNER_RESPONSE':
            for tc in data.get('tool_calls', []):
                args = tc.get('args', {})
                if 'Frm_generatefee_multi' in str(args.get('TargetFile', '')):
                    print("TOOL:", tc.get('name'))
                    print("DESC:", args.get('Description'))
                    if 'ReplacementChunks' in args:
                        chunks = args['ReplacementChunks']
                        if isinstance(chunks, str):
                            try:
                                chunks = json.loads(chunks, strict=False)
                            except Exception:
                                chunks = []
                        for c in chunks:
                            print("CHUNK target lines:", c.get('StartLine'), "-", c.get('EndLine'))
                            print("CHUNK target:\n", c.get('TargetContent')[:200])
                            print("CHUNK repl:\n", c.get('ReplacementContent')[:200])
                    elif 'ReplacementContent' in args:
                        print("REPL lines:", args.get('StartLine'), "-", args.get('EndLine'))
                        print("TARGET:\n", args.get('TargetContent')[:200])
                        print("REPL:\n", args.get('ReplacementContent')[:200])
                    print("="*60)
