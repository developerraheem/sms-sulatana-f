with open('Report_DataSet_new.xsd', 'r', encoding='utf-8') as f:
    text = f.read()

import re
matches = re.findall(r'FROM\s+FEE_DETAIL\s+AS\s+A[\s\S]*?Fee_Head\.Fee_head_id', text)
for m in matches:
    print("MATCH:\n", repr(m))
