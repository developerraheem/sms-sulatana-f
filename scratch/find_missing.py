with open('Report_DataSet_new.Designer.cs', 'r', encoding='utf-8') as f:
    lines = f.readlines()

for i, line in enumerate(lines):
    if 'class ' in line and 'TableAdapter' in line:
        print(f"Line {i+1}: {line.strip()}")
    if 'CommandCollection[' in line or 'CommandText =' in line:
        # check if FEE_MASTER or Sections in following lines
        snippet = "".join(lines[max(0, i-2):min(len(lines), i+15)])
        if 'Sections' in snippet and 'BRANCH_ID' not in snippet:
            print(f"Line {i+1} MISSING BRANCH_ID in Sections: {line.strip()[:100]}")
            for k in range(max(0, i-5), min(len(lines), i+12)):
                if 'class ' in lines[k] or 'CommandText' in lines[k] or 'FROM' in lines[k] or 'WHERE' in lines[k]:
                    print(f"   {k+1}: {lines[k].strip()[:120]}")
