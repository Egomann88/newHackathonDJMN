<template>
  <div class="min-h-screen bg-[#cbcbcb] py-4">
    <div class="flex flex-wrap overflow-hidden w-1/3 m-auto pt-2 mt-1/2 transform translate-y-1/2">
      <div class="w-full px-4">
        <div class="flex flex-wrap w-full overflow-hidden py-4 bg-gray-100 p-4">
          <div class="w-full overflow-hidden py-4">
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">E-Mail</p>
                <input class="p-2 rounded-b-sm w-full" id="emailInput" type="email" required>
              </div>
            </div>
            <div class="w-full py-2 px-4 ">
              <div class="border-black border-2 rounded-sm">
                <p class="text-center bg-[#519ad6] rounded-t-sm">Passwort</p>
                <input class="p-2 rounded-b-sm w-full" id="passwordInput" type="password" required>
              </div>
            </div>
          </div>
          <div class="w-full px-4">
            <button @click="checkLogin()" class="button w-full my-4 bg-green-300 hover:bg-green-400" type="submit"
              value="submit" >Einloggen</button>
          </div>
        </div>
      </div>
    </div>
  </div>
</template>

<script>
import { defineComponent } from "vue";
export default defineComponent({
  components: {},
  setup() { },
  mounted() {
    this.createLS();
  },
  methods: {
   

    createLS() {
      if (!localStorage.getItem("loggedIn")) localStorage.setItem("loggedIn", "0");
    },

    checkLogin() {
      fetch('http://localhost:34474/api/user')
      .then(res => {
          return res.json();
        })
        .then(data => {
          var pw = document.getElementById("passwordInput").value; // Ueli.Schneider@test.ch
          var email = document.getElementById("emailInput").value; // starwars
          
          pw = pw.trim(' ');
          email = email.trim(' ').toLowerCase();
        



          data.forEach(x => {
           if(x.UserPassword.trim(' ') == pw && x.UserEmail.trim(' ').toLowerCase() == email){
             localStorage.setItem("UserID", x.ID);
             localStorage.setItem("loggedIn", "1");
             window.location = "/calendar";
           }

          
        });
      })
    }
  },
});
</script>

<style scoped>

</style>