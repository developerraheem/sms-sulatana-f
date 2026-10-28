import re

def inspect_file(filename):
    print(f"=== Inspecting {filename} ===")
    with open(filename, 'r', encoding='utf-8') as f:
        content = f.read()
    
    # Find all SELECT ... FROM queries
    matches = re.findall(r'(SELECT[\s\S]*?FROM[\s\S]*?(?:ORDER BY|WHERE[\s\S]*?(?:ORDER BY|;|\"|\<)))', content, re.IGNORECASE)
    print(f"Found {len(matches)} query snippets")
    for i, m in enumerate(matches):
        if 'FEE_MASTER' in m:
            clean = " ".join(m.split())
            print(f"--- Query {i+1} with FEE_MASTER ---")
            print(clean[:300])
            # Check Sections join
            if 'Sections' in m:
                if 'Sections.BRANCH_ID' in m:
                    print("  [OK] Sections.BRANCH_ID present")
                else:
                    print("  [MISSING] Sections.BRANCH_ID NOT present in Sections join!")
            if 'FEE_MASTER.branch_id' in m:
                print("  [OK] FEE_MASTER.branch_id present")
            else:
                print("  [MISSING] FEE_MASTER.branch_id NOT present!")

inspect_file('Report_DataSet_new.xsd')
inspect_file('Report_DataSet_new.Designer.cs')
