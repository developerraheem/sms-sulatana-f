import zipfile
import xml.etree.ElementTree as ET

# Create a minimal valid .xlsx file
# A minimal xlsx contains:
# [Content_Types].xml
# _rels/.rels
# xl/_rels/workbook.xml.rels
# xl/workbook.xml
# xl/sharedStrings.xml
# xl/worksheets/sheet1.xml

with zipfile.ZipFile('scratch/test_fine.xlsx', 'w', zipfile.ZIP_DEFLATED) as z:
    z.writestr('[Content_Types].xml', '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Types xmlns="http://schemas.openxmlformats.org/package/2006/content-types">
  <Default Extension="rels" ContentType="application/vnd.openxmlformats-package.relationships+xml"/>
  <Default Extension="xml" ContentType="application/xml"/>
  <Override PartName="/xl/workbook.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sheet.main+xml"/>
  <Override PartName="/xl/worksheets/sheet1.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.worksheet+xml"/>
  <Override PartName="/xl/sharedStrings.xml" ContentType="application/vnd.openxmlformats-officedocument.spreadsheetml.sharedStrings+xml"/>
</Types>''')

    z.writestr('_rels/.rels', '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
  <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/officeDocument" Target="xl/workbook.xml"/>
</Relationships>''')

    z.writestr('xl/_rels/workbook.xml.rels', '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<Relationships xmlns="http://schemas.openxmlformats.org/package/2006/relationships">
  <Relationship Id="rId1" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/worksheet" Target="worksheets/sheet1.xml"/>
  <Relationship Id="rId2" Type="http://schemas.openxmlformats.org/officeDocument/2006/relationships/sharedStrings" Target="sharedStrings.xml"/>
</Relationships>''')

    z.writestr('xl/workbook.xml', '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<workbook xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main">
  <sheets>
    <sheet name="Sheet1" sheetId="1" r:id="rId1" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships"/>
  </sheets>
</workbook>''')

    # Shared strings: Student ID, Student Name, Class Name, Fine, Reason, Late fee, Uniform fine
    shared_strings = [
        "Student ID", "Student Name", "Class Name", "Fine", "Reason",
        "2093", "SYEDA KINZA BIBI", "PM-1G", "Late arrival",
        "2106", "UROOSA QAYUM", "PM-1G", "Uniform fine"
    ]
    ss_xml = ['<?xml version="1.0" encoding="UTF-8" standalone="yes"?>',
              f'<sst xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main" count="{len(shared_strings)}" uniqueCount="{len(shared_strings)}">']
    for s in shared_strings:
        ss_xml.append(f'<si><t>{s}</t></si>')
    ss_xml.append('</sst>')
    z.writestr('xl/sharedStrings.xml', ''.join(ss_xml))

    # Sheet1:
    # Row 1: Student ID (0), Student Name (1), Class Name (2), Fine (3), Reason (4)
    # Row 2: 2093 (5), SYEDA KINZA BIBI (6), PM-1G (7), 200 (num), Late arrival (8)
    # Row 3: 2106 (9), UROOSA QAYUM (10), PM-1G (11), 350 (num), Uniform fine (12)
    sheet_xml = '''<?xml version="1.0" encoding="UTF-8" standalone="yes"?>
<worksheet xmlns="http://schemas.openxmlformats.org/spreadsheetml/2006/main">
  <sheetData>
    <row r="1">
      <c r="A1" t="s"><v>0</v></c>
      <c r="B1" t="s"><v>1</v></c>
      <c r="C1" t="s"><v>2</v></c>
      <c r="D1" t="s"><v>3</v></c>
      <c r="E1" t="s"><v>4</v></c>
    </row>
    <row r="2">
      <c r="A2" t="s"><v>5</v></c>
      <c r="B2" t="s"><v>6</v></c>
      <c r="C2" t="s"><v>7</v></c>
      <c r="D2"><v>200</v></c>
      <c r="E2" t="s"><v>8</v></c>
    </row>
    <row r="3">
      <c r="A3" t="s"><v>9</v></c>
      <c r="B3" t="s"><v>10</v></c>
      <c r="C3" t="s"><v>11</v></c>
      <c r="D3"><v>350</v></c>
      <c r="E3" t="s"><v>12</v></c>
    </row>
  </sheetData>
</worksheet>'''
    z.writestr('xl/worksheets/sheet1.xml', sheet_xml)

print("Created scratch/test_fine.xlsx successfully")
