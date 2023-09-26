<script setup lang="ts">
import ListItem from "./ListItem.vue";
import BookInput from "./BookInput.vue";
import IBook from "../modules/Interfaces/IBook";
import ActionButton from "./ActionButton.vue";
import useBookStore from "../stores/bookStore";
import ButtonTypesEnum from "../modules/enums/buttonTypesEnum";

const bookStore = useBookStore();

const customBook: IBook = {
  bookId: 0,
  author: "",
  title: "",
  year: 0,
};

const addBookCustomBook = () => {
  bookStore.addBook(customBook);
};

const clearBookInput = () => {
  console.log("clearBookInput");
  customBook.author = "";
  customBook.title = "";
  customBook.year = 0;
};
</script>

<template>
  <ListItem>
    <BookInput
      input-type="text"
      place-holder="Title"
      v-model="customBook.title"
    />
    <BookInput
      input-type="text"
      place-holder="Author"
      v-model="customBook.author"
    />
    <BookInput
      input-type="number"
      place-holder="Release year"
      v-model="customBook.year"
    />
    <div class="flex flex-row gap-1">
      <ActionButton
        :buttosn-type="ButtonTypesEnum.AcceptButton"
        @action="addBookCustomBook"
      >
        Add book
      </ActionButton>
      <ActionButton
        :buttosn-type="ButtonTypesEnum.CancelButton"
        @action="clearBookInput"
      >
        Clear
      </ActionButton>
    </div>
  </ListItem>
</template>
