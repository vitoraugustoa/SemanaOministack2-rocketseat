import React, { FormEvent, useState } from 'react';
import { useHistory } from 'react-router-dom';

import './styles.css';

import PageHeader from '../../components/PageHeader';
import Input from '../../components/Input';
import Textarea from '../../components/Textarea';
import Select from '../../components/Select';
import warningIcon from '../../assets/images/icons/warning.svg';
import api from '../../services/api';

export default function TeacherForm() {
  const history = useHistory();
  const [name, setName] = useState("");
  const [avatar, setAvatar] = useState("");
  const [whatsapp, setWhatsapp] = useState("");
  const [bio, setBio] = useState("");
  const [subject, setSubject] = useState("");
  const [cost, setCost] = useState("");


  const [scheduleItems, setScheduleItems] = useState([
    { weekday: 0, from: 0, to: 0 },
  ])

  function addNewScheduleItem() {
    setScheduleItems([
      ...scheduleItems,
      {
        weekday: 0,
        from: 0,
        to: 0
      }
    ]);
  }

  function setScheduleItemValue(position: number, field: string, value: number) {
   const updatedScheduleItems = scheduleItems.map((item, index) => {
    if(index === position) {
      return { ...item, [field]: value }; 
    }

    return item;
   }); 

   setScheduleItems(updatedScheduleItems);
  }

  function handleCreateClass() {
    api.post('users', {
      user: {
        name,
        avatar,
        whatsapp,
        bio
      },
      class: {
        subject,
        cost: Number(cost)
      },
      ClassSchedule: scheduleItems
    }).then(() => {
      alert("Cadastro realizado com sucesso!");
      history.push('/');
    }).catch(() => {
      alert("Erro no cadastro!");
    });
  }

  return (
    <div id="page-teacher-form" className="container">
      <PageHeader
        title="Que inscrivel que vocÊ quer dar aulas."
        description="O primeiro passo é preencher esse formulário de inscrição." />

      <main>
        <form onSubmit={(event: FormEvent) => {
          event.preventDefault();
          handleCreateClass();
        }}>
          <fieldset>
            <legend>Seus dados</legend>
            <Input
              name="name"
              label="Nome Completo"
              value={name}
              onChange={(e) => setName(e.target.value)}
            />

            <Input
              name="avatar"
              label="Avatar"
              value={avatar}
              onChange={(e) => setAvatar(e.target.value)}
            />

            <Input
              name="whatsapp"
              label="Whatsapp"
              value={whatsapp}
              onChange={(e) => setWhatsapp(e.target.value)}
            />

            <Textarea
              name="bio"
              label="biografia"
              value={bio}
              onChange={(e) => setBio(e.target.value)}
            />
          </fieldset>

          <fieldset>
            <legend>Sobre a aula</legend>
            <Select
              name="subject"
              label="Matéria"
              value={subject}
              onChange={(e) => setSubject(e.target.value)}
              options={[
                { value: "Artes", label: "Artes" },
                { value: "Biologia", label: "Biologia" },
                { value: "Ciências", label: "Ciências" },
                { value: "Educação fisica", label: "Educação fisica" },
                { value: "Fisica", label: "Fisica" },
                { value: "Geografia", label: "Geografia" },
                { value: "Historia", label: "Historia" },
                { value: "Matematica", label: "Matematica" },
                { value: "Portugues", label: "Portugues" },
                { value: "Quimica", label: "Quimica" },
              ]}
            />

            <Input
              name="cost"
              label="Custo da sua hora por aula"
              type="text"
              value={cost}
              onChange={(e) => setCost(e.target.value)}
            />
          </fieldset>

          <fieldset>
            <legend>
              Horários disponíveis
            <button type="button" onClick={addNewScheduleItem}>
                + Novo horário
            </button>
            </legend>

            {scheduleItems.map((scheduleItem, index) => {
              return (
                <div key={index} className="schedule-item">
                  <Select
                    name="weekday"
                    label="Dia da semana"
                    value={scheduleItem.weekday}
                    onChange={e => setScheduleItemValue(index, 'weekday', Number(e.target.value))}
                    options={[
                      { value: "0", label: "Domingo" },
                      { value: "1", label: "Segunda-feira" },
                      { value: "2", label: "Terça-feira" },
                      { value: "3", label: "Quarta-feira" },
                      { value: "4", label: "Quinta-feira" },
                      { value: "5", label: "Sexta-feira" },
                      { value: "6", label: "Sabado" },
                    ]}
                  />

                  <Input
                    name="from" 
                    label="Das"
                    type="text"
                    value={scheduleItem.from}
                    onChange={e => setScheduleItemValue(index, 'from', Number(e.target.value))}
                  />

                  <Input
                    name="to"
                    label="Até"
                    type="text"
                    value={scheduleItem.to}
                    onChange={e => setScheduleItemValue(index, 'to', Number(e.target.value))}
                  />
                </div>
              );
            })}

          </fieldset>

          <footer>
            <p>
              <img src={warningIcon} alt="Aviso importante" />
            Importante! <br />
            Preencha todos os dados
          </p>
            <button type="submit">Salvar cadastro</button>
          </footer>
        </form>
      </main>
    </div>
  );
}