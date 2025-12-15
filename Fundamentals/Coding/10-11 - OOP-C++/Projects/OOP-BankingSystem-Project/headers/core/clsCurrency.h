#pragma once
#include<iostream>
#include<string>
#include "../lib/clsString.h"
#include <vector>
#include <fstream>
using namespace std;

class clsCurrency
{

private:

    enum enMode { EmptyMode = 0, UpdateMode = 1 };
    enMode _Mode;

	string _Country;
	string _CurrencyCode;
	string _CurrencyName;
	float _Rate;

    static clsCurrency _ConvertLinetoCurrencyObject(string Line, string Seperator = "#//#")
    {
        vector<string> vCurrencyData;
        vCurrencyData = clsString::Split(Line, Seperator);
        return clsCurrency(enMode::UpdateMode, vCurrencyData[0], vCurrencyData[1], vCurrencyData[2],
            stof(vCurrencyData[3]));
    }

    static string _ConverCurrencyObjectToLine(clsCurrency Currency, string Seperator = "#//#")
    {
        string CurrencyRecord = "";

        CurrencyRecord += Currency.Country() + Seperator;
        CurrencyRecord += Currency.CurrencyCode() + Seperator;
        CurrencyRecord += Currency.CurrencyName() + Seperator;
        CurrencyRecord += to_string(Currency.Rate());

        return CurrencyRecord;
    }

    static  vector <clsCurrency> _LoadCurrencysDataFromFile()
    {
        vector <clsCurrency> vCurrencys;

        fstream MyFile;
        MyFile.open("Currencies.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsCurrency Currency = _ConvertLinetoCurrencyObject(Line);
                vCurrencys.push_back(Currency);
            }
            MyFile.close();
        }
        return vCurrencys;
    }

    static void _SaveCurrencyDataToFile(vector<clsCurrency> vCurrencies)
    {
        string DataLine;

        fstream MyFile;
        MyFile.open("Currencies.txt", ios::out);//overwrite
        
        if (MyFile.is_open())
        {
            for (clsCurrency C : vCurrencies)
            {
                DataLine = _ConverCurrencyObjectToLine(C);
                MyFile << DataLine << endl;
            }
            MyFile.close();
        }
    }

    void _Update()
    {
        if(this->IsEmpty())
            return;
            
        vector <clsCurrency> _vCurrencys;
        _vCurrencys = _LoadCurrencysDataFromFile();

        // By ref is crucial to modify the original object, so when we save it, it will be saved with the new rate.
        for (clsCurrency &C : _vCurrencys)
        {
            // we are modifying the rate of the currency with the same code
            if (C.CurrencyCode() == CurrencyCode())
            {
                C._Rate = _Rate;
            }
        }
        // The vector is updated since we used by ref, now we save it to the file.
        _SaveCurrencyDataToFile(_vCurrencys);
    }

    static clsCurrency _GetEmptyCurrencyObject()
    {
        return clsCurrency(enMode::EmptyMode, "", "", "", 0);
    }

public:

	clsCurrency(enMode Mode,string Country,string CurrencyCode,string CurrencyName,float Rate)
	{
        _Mode = Mode;
        _Country = Country;
        _CurrencyCode = CurrencyCode;
        _CurrencyName = CurrencyName;
        _Rate = Rate;
	}

	static vector <clsCurrency> GetAllUSDRates()
	{
        return _LoadCurrencysDataFromFile();
	}

    bool IsEmpty()
    {
        return (_Mode == enMode::EmptyMode);
    }

    string Country()
    {
        return _Country;
    }

    string CurrencyCode()
    {
        return _CurrencyCode;
    }
    
    string CurrencyName()
    {
        return _CurrencyName;
    }

    void UpdateRate(float NewRate)
    {
        _Rate = NewRate;
        _Update();
    }

    float Rate()
    {
        return _Rate;
    }

    static clsCurrency FindByCode(string CurrencyCode)
    {
        CurrencyCode = clsString::UpperAllString(CurrencyCode);

        fstream MyFile;
        MyFile.open("Currencies.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsCurrency Currency = _ConvertLinetoCurrencyObject(Line);
                if (Currency.CurrencyCode() == CurrencyCode)
                {
                    MyFile.close();
                    return Currency;
                }
            }
            MyFile.close();
        }
        return _GetEmptyCurrencyObject();
    }

    static clsCurrency FindByCountry(string Country)
    {
        Country = clsString::UpperAllString(Country);

        fstream MyFile;
        MyFile.open("Currencies.txt", ios::in);//read Mode

        if (MyFile.is_open())
        {
            string Line;
            while (getline(MyFile, Line))
            {
                clsCurrency Currency = _ConvertLinetoCurrencyObject(Line);
                if (clsString::UpperAllString(Currency.Country()) == Country)
                {
                    MyFile.close();
                    return Currency;
                }
            }
            MyFile.close();
        }
        return _GetEmptyCurrencyObject();
    }

    static bool IsCurrencyExist(string CurrencyCode)
    {
        clsCurrency C1 = clsCurrency::FindByCode(CurrencyCode);
        return (!C1.IsEmpty());
    }

    static vector <clsCurrency> GetCurrenciesList()
    {
        return _LoadCurrencysDataFromFile();
    }

    float ConvertToUsd(float Amount)
    {
        return float(Amount / Rate());
    }

    float ConvertFromUsd(float Amount)
    {
        return float(Amount * Rate());
    }
};



