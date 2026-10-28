import os, glob, json, datetime

brains = glob.glob(r'C:\Users\nahee\.gemini\antigravity-ide\brain\*')
results = []
for b in brains:
    log = os.path.join(b, '.system_generated', 'logs', 'transcript.jsonl')
    if os.path.isfile(log):
        mtime = os.path.getmtime(log)
        # get first user input
        first_input = ""
        with open(log, 'r', encoding='utf-8') as f:
            for line in f:
                d = json.loads(line)
                if d.get('type') == 'USER_INPUT':
                    first_input = d.get('content', '')[:120].replace('\n', ' ')
                    break
        results.append((mtime, os.path.basename(b), datetime.datetime.fromtimestamp(mtime).strftime('%Y-%m-%d %H:%M'), first_input))

results.sort(reverse=True)
for r in results[:15]:
    print(f"{r[2]} | {r[1]} | {r[3]}")
