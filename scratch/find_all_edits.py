import json, glob

brains = glob.glob(r'C:\Users\nahee\.gemini\antigravity-ide\brain\*')
for b in brains:
    log = b + r'\.system_generated\logs\transcript_full.jsonl'
    try:
        with open(log, 'r', encoding='utf-8') as f:
            for line in f:
                if 'LoadBranchVoucherNote' in line and ('replace_file_content' in line or 'multi_replace_file_content' in line or 'write_to_file' in line):
                    d = json.loads(line)
                    for tc in d.get('tool_calls', []):
                        if 'BranchVoucher' in str(tc) or 'txtnotes' in str(tc):
                            print("BRAIN:", b)
                            print("TOOL:", tc.get('name'))
                            print("DESC:", tc.get('args', {}).get('Description'))
                            print("CONTENT:\n", str(tc.get('args'))[:1500])
                            print("="*60)
    except Exception:
        pass
