import xml.etree.ElementTree as ET

tree = ET.parse('DataSet_Fee_Summary_Reports.xsd')
root = tree.getroot()

for ta in root.iter('{urn:schemas-microsoft-com:xml-msdatasource}TableAdapter'):
    name = ta.attrib.get('Name')
    print(f"=== TableAdapter: {name} ===")
    for cmd in ta.iter('{urn:schemas-microsoft-com:xml-msdatasource}DbCommand'):
        cmd_text_el = cmd.find('{urn:schemas-microsoft-com:xml-msdatasource}CommandText')
        if cmd_text_el is not None and cmd_text_el.text:
            text = " ".join(cmd_text_el.text.split())
            if any(tbl in text for tbl in ['FEE_MASTER', 'Sections', 'student', 'FEE_DETAIL', 'view_fee']):
                print(f"  Command: {text[:250]}...")
                if 'Sections' in text and 'Sections.BRANCH_ID' not in text:
                    print("  --> [ALERT] Sections without Sections.BRANCH_ID!")
                if 'student' in text and 'FEE_MASTER' in text and 'FEE_MASTER.branch_id = student.branch_id' not in text and 'f.branch_id=s.branch_id' not in text:
                    print("  --> [ALERT] FEE_MASTER and student without branch match!")
                if 'FEE_DETAIL' in text and 'FEE_MASTER' in text:
                    if 'FEE_MASTER.branch_id = FEE_DETAIL.branch_id' not in text:
                        print("  --> [ALERT] FEE_DETAIL without branch match!")
                    if 'FEE_MASTER.SessionID = FEE_DETAIL.SessionID' not in text:
                        print("  --> [ALERT] FEE_DETAIL without SessionID match!")
