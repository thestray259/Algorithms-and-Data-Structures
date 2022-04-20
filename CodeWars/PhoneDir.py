import re
def phone(strng,num):
    lines = []
    lines = strng.split('\n')
    #print(lines)
    lists = []
    count = 0
    
    
    for i in range(len(lines)-1):
        pattern1=re.compile('.\d\-\d\d\d\-\d\d\d\-\d\d\d\d')
        Phone1=pattern1.findall(lines[i])
        Phone2=re.sub('[\+]','',Phone1[0])
        #print(Phone2)
        

        pattern2=re.compile('\<.*\>')
        Name1=pattern2.findall(lines[i])
        #print(Name1[0])
        

        Address1=re.sub('[\/\,\+\;\*]','',lines[i])
        Address2=Address1.replace(Phone2,'')
        Address3=Address2.replace(Name1[0],'').strip()
        Address4=re.sub('[\_\$\!\?\:]',' ',Address3)
        #print(Address4)
        Address4=Address4.split()
        #print(Address4)
        Address5=" ".join(Address4)
        #print(Address5)
        
        str1 = Phone2+'/'+Name1[0]+'/'+Address5
        #print(str1)
        
        lists.append(str1.split("/"))
        #print(lists)
        
    for i in range(len(lists)):
        if num == lists[i][0]:
            count += 1
    if count == 0:
        str2 = "Error => Not found: "+num
        return str2
    elif count == 1:
        for i in range(len(lists)):
            if num == lists[i][0]:
                Name2 = re.sub('[\<\>]','',lists[i][1])
                str3 = "Phone => "+lists[i][0]+", Name => "+Name2+", Address => "+lists[i][2]
        return str3
    else:
        str4 = "Error => Too many people: "+num
        return str4