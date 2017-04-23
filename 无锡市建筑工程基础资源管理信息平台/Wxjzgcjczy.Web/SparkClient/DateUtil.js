/**
* ���ڴ�������
*/

var DateUtil = function(){

    /**
     * �ж�����
     * @param date Date���ڶ���
     * @return boolean true ��false
     */
    this.isLeapYear = function(date){
        return (0==date.getYear()%4&&((date.getYear()%100!=0)||(date.getYear()%400==0))); 
    }
    
    /**
     * ���ڶ���ת��Ϊָ����ʽ���ַ���
     * @param f ���ڸ�ʽ,��ʽ�������� yyyy-MM-dd HH:mm:ss
     * @param date Date���ڶ���, ���ȱʡ����Ϊ��ǰʱ��
     *
     * YYYY/yyyy/YY/yy ��ʾ���  
     * MM/M �·�  
     * W/w ����  
     * dd/DD/d/D ����  
     * hh/HH/h/H ʱ��  
     * mm/m ����  
     * ss/SS/s/S ��  
     * @return string ָ����ʽ��ʱ���ַ���
     */
    this.dateToStr = function(formatStr, date){
        formatStr = arguments[0] || "yyyy-MM-dd HH:mm:ss";
        date = arguments[1] || new Date();
        var str = formatStr;   
        var Week = ['��','һ','��','��','��','��','��'];  
        str=str.replace(/yyyy|YYYY/,date.getFullYear());   
        str=str.replace(/yy|YY/,(date.getYear() % 100)>9?(date.getYear() % 100).toString():'0' + (date.getYear() % 100));   
        str=str.replace(/MM/,date.getMonth()>=9?(date.getMonth() + 1):'0' + (date.getMonth() + 1));   
        str=str.replace(/M/g,date.getMonth());   
        str=str.replace(/w|W/g,Week[date.getDay()]);   
      
        str=str.replace(/dd|DD/,date.getDate()>9?date.getDate().toString():'0' + date.getDate());   
        str=str.replace(/d|D/g,date.getDate());   
      
        str=str.replace(/hh|HH/,date.getHours()>9?date.getHours().toString():'0' + date.getHours());   
        str=str.replace(/h|H/g,date.getHours());   
        str=str.replace(/mm/,date.getMinutes()>9?date.getMinutes().toString():'0' + date.getMinutes());   
        str=str.replace(/m/g,date.getMinutes());   
      
        str=str.replace(/ss|SS/,date.getSeconds()>9?date.getSeconds().toString():'0' + date.getSeconds());   
        str=str.replace(/s|S/g,date.getSeconds());   
      
        return str;   
    }

    
    /**
    * ���ڼ���  
    * @param strInterval string  ��ѡֵ y �� m�� d�� w���� ww�� hʱ n�� s��  
    * @param num int
    * @param date Date ���ڶ���
    * @return Date �������ڶ���
    */
    this.dateAdd = function(strInterval, num, date){
        date =  arguments[2] || new Date();
        switch (strInterval) { 
            case 's' :return new Date(date.getTime() + (1000 * num));  
            case 'n' :return new Date(date.getTime() + (60000 * num));  
            case 'h' :return new Date(date.getTime() + (3600000 * num));  
            case 'd' :return new Date(date.getTime() + (86400000 * num));  
            case 'w' :return new Date(date.getTime() + ((86400000 * 7) * num));  
            case 'm' :return new Date(date.getFullYear(), (date.getMonth()) + num, date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds());  
            case 'y' :return new Date((date.getFullYear() + num), date.getMonth(), date.getDate(), date.getHours(), date.getMinutes(), date.getSeconds());  
        }  
    }  
    
    /**
    * �Ƚ����ڲ� dtEnd ��ʽΪ�����ͻ�����Ч���ڸ�ʽ�ַ���
    * @param strInterval string  ��ѡֵ y �� m�� d�� w���� ww�� hʱ n�� s��  
    * @param dtStart Date  ��ѡֵ y �� m�� d�� w���� ww�� hʱ n�� s��
    * @param dtEnd Date  ��ѡֵ y �� m�� d�� w���� ww�� hʱ n�� s�� 
    */
    this.dateDiff = function(strInterval, dtStart, dtEnd) {   
        switch (strInterval) {   
            case 's' :return parseInt((dtEnd - dtStart) / 1000);  
            case 'n' :return parseInt((dtEnd - dtStart) / 60000);  
            case 'h' :return parseInt((dtEnd - dtStart) / 3600000);  
            case 'd' :return parseInt((dtEnd - dtStart) / 86400000);  
            case 'w' :return parseInt((dtEnd - dtStart) / (86400000 * 7));  
            case 'm' :return (dtEnd.getMonth()+1)+((dtEnd.getFullYear()-dtStart.getFullYear())*12) - (dtStart.getMonth()+1);  
            case 'y' :return dtEnd.getFullYear() - dtStart.getFullYear();  
        }  
    }

    /**
    * �ַ���ת��Ϊ���ڶ���
    * @param date Date ��ʽΪyyyy-MM-dd HH:mm:ss�����밴������ʱ�����˳���м�ָ���������
    */
    this.strToDate = function(dateStr){
        var data = dateStr;  
        var reCat = /(\d{1,4})/gm;   
        var t = data.match(reCat);
        t[1] = t[1] - 1;
        eval('var d = new Date('+t.join(',')+');');
        return d;
    }

    /**
    * ��ָ����ʽ���ַ���ת��Ϊ���ڶ���yyyy-MM-dd HH:mm:ss
    * 
    */
    this.strFormatToDate = function(formatStr, dateStr){
        var year = 0;
        var start = -1;
        var len = dateStr.length;
        if((start = formatStr.indexOf('yyyy')) > -1 && start < len){
            year = dateStr.substr(start, 4);
        }
        var month = 0;
        if((start = formatStr.indexOf('MM')) > -1  && start < len){
            month = parseInt(dateStr.substr(start, 2)) - 1;
        }
        var day = 0;
        if((start = formatStr.indexOf('dd')) > -1 && start < len){
            day = parseInt(dateStr.substr(start, 2));
        }
        var hour = 0;
        if( ((start = formatStr.indexOf('HH')) > -1 || (start = formatStr.indexOf('hh')) > 1) && start < len){
            hour = parseInt(dateStr.substr(start, 2));
        }
        var minute = 0;
        if((start = formatStr.indexOf('mm')) > -1  && start < len){
            minute = dateStr.substr(start, 2);
        }
        var second = 0;
        if((start = formatStr.indexOf('ss')) > -1  && start < len){
            second = dateStr.substr(start, 2);
        }
        return new Date(year, month, day, hour, minute, second);
    }


    /**
    * ���ڶ���ת��Ϊ������
    */
    this.dateToLong = function(date){
        return date.getTime();
    }

    /**
    * ����ת��Ϊ���ڶ���
    * @param dateVal number ���ڵĺ����� 
    */
    this.longToDate = function(dateVal){
        return new Date(dateVal);
    }

    /**
    * �ж��ַ����Ƿ�Ϊ���ڸ�ʽ
    * @param str string �ַ���
    * @param formatStr string ���ڸ�ʽ�� ���� yyyy-MM-dd
    */
    this.isDate = function(str, formatStr){
        if (formatStr == null){
            formatStr = "yyyyMMdd";    
        }
        var yIndex = formatStr.indexOf("yyyy");     
        if(yIndex==-1){
            return false;
        }
        var year = str.substring(yIndex,yIndex+4);     
        var mIndex = formatStr.indexOf("MM");     
        if(mIndex==-1){
            return false;
        }
        var month = str.substring(mIndex,mIndex+2);     
        var dIndex = formatStr.indexOf("dd");     
        if(dIndex==-1){
            return false;
        }
        var day = str.substring(dIndex,dIndex+2);     
        if(!isNumber(year)||year>"2100" || year< "1900"){
            return false;
        }
        if(!isNumber(month)||month>"12" || month< "01"){
            return false;
        }
        if(day>getMaxDay(year,month) || day< "01"){
            return false;
        }
        return true;   
    }
    
    this.getMaxDay = function(year,month) {     
        if(month==4||month==6||month==9||month==11)     
            return "30";     
        if(month==2)     
            if(year%4==0&&year%100!=0 || year%400==0)     
                return "29";     
            else     
                return "28";     
        return "31";     
    }     
    /**
    *    �����Ƿ�Ϊ����
    */
    this.isNumber = function(str)
    {
        var regExp = /^\d+$/g;
        return regExp.test(str);
    }
    
    /**
    * �����ڷָ������ [�ꡢ�¡��ա�ʱ���֡���]
    */
    this.toArray = function(myDate)  
    {   
        myDate = arguments[0] || new Date();
        var myArray = Array();  
        myArray[0] = myDate.getFullYear();  
        myArray[1] = myDate.getMonth();  
        myArray[2] = myDate.getDate();  
        myArray[3] = myDate.getHours();  
        myArray[4] = myDate.getMinutes();  
        myArray[5] = myDate.getSeconds();  
        return myArray;  
    }  
    
    /**
    * ȡ������������Ϣ  
    * ���� interval ��ʾ��������  
    * y �� M�� d�� w���� ww�� hʱ n�� s��  
    */
    this.datePart = function(interval, myDate)  
    {   
        myDate = arguments[1] || new Date();
        var partStr='';  
        var Week = ['��','һ','��','��','��','��','��'];  
        switch (interval)  
        {   
            case 'y' :partStr = myDate.getFullYear();break;  
            case 'M' :partStr = myDate.getMonth()+1;break;  
            case 'd' :partStr = myDate.getDate();break;  
            case 'w' :partStr = Week[myDate.getDay()];break;  
            case 'ww' :partStr = myDate.WeekNumOfYear();break;  
            case 'h' :partStr = myDate.getHours();break;  
            case 'm' :partStr = myDate.getMinutes();break;  
            case 's' :partStr = myDate.getSeconds();break;  
        }  
        return partStr;  
    }  
    
    /**
    * ȡ�õ�ǰ���������µ��������  
    */
    this.maxDayOfDate = function(date)  
    {   
        date = arguments[0] || new Date();
        date.setDate(1);
        date.setMonth(date.getMonth() + 1);
        var time = date.getTime() - 24 * 60 * 60 * 1000;
        var newDate = new Date(time);
        return newDate.getDate();
    }
    
    return this;
}(); 