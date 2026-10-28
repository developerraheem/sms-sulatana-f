import json

path = r'C:\Users\nahee\.gemini\antigravity-ide\brain\e2dbacc9-f84f-4b6b-aabe-37d16df0902d\.system_generated\logs\transcript_full.jsonl'
with open(path, 'r', encoding='utf-8') as f:
    for line in f:
        data = json.loads(line)
        if data.get('type') == 'PLANNER_RESPONSE':
            for tc in data.get('tool_calls', []):
                args = tc.get('args', {})
                if 'BranchVoucherRemarks' in str(args):
                    print("TOOL:", tc.get('name'))
                    print("DESC:", args.get('Description'))
                    print("TARGET:\n", args.get('TargetContent'))
                    print("REPLACEMENT:\n", args.get('ReplacementContent'))
                    print("="*60)
