﻿
using ClinicAppointmentModelLibrary;
using System.Collections.Generic;

namespace ClinicAppointmentDALLibrary
{
    public class PatientRepository : IRepository<int, Patient>
    {
        public Dictionary<int, Patient> _patients;
        public PatientRepository() 
        {
            _patients = new Dictionary<int, Patient>();
        }

        int GenerateId()
        {
            if (_patients.Count == 0)
                return 100;
            int id = _patients.Keys.Max();
            return ++id;
        }

        public Patient Add(Patient item)
        {
            if (_patients.ContainsValue(item))
            {
                return null;
            }
            _patients.Add(GenerateId(), item);
            return item;
        }

        public Patient Delete(int key)
        {
            if (_patients.ContainsKey(key))
            {
                var patients = _patients[key];
                _patients.Remove(key);
                return patients;
            }
            return null;
        }

        public Patient Get(int key)
        {
            return _patients.ContainsKey(key) ? _patients[key] : null;
        }

        public List<Patient> GetAll()
        {
            if (_patients.Count == 0)
                return null;
            return _patients.Values.ToList();
        }

        public Patient Update(Patient item)
        {
            if (_patients.ContainsKey(item.Id))
            {
                _patients[item.Id] = item;
                return item;
            }
            return null;
        }
    }
}