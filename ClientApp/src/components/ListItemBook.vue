<script setup lang="ts">
import ListItem from "./ListItem.vue";
import IBook from "../modules/Interfaces/IBook";
import ActionButton from "./ActionButton.vue";
import ButtonTypesEnum from "../modules/enums/buttonTypesEnum";
import { ref } from "vue";
import BookInput from "./BookInput.vue";
import useBookStore from "../stores/bookStore";

const props = defineProps<{
  book: IBook;
}>();

const bookStore = useBookStore();
const isEditMode = ref<boolean>(false);
const bookBuffer: IBook = {
  bookId: props.book.bookId,
  title: props.book.title,
  author: props.book.author,
  year: props.book.year,
};

const switchModes = () => {
  isEditMode.value = !isEditMode.value;
  bookBuffer.bookId = props.book.bookId;
  bookBuffer.title = props.book.title;
  bookBuffer.author = props.book.author;
  bookBuffer.year = props.book.year;
};

const saveChanges = () => {
  bookStore.updateBook(bookBuffer);
  switchModes();
};

// Deosnt need to be reactive
const removeBook = (): void => bookStore.removeBook(props.book.bookId);
</script>

<template>
  <ListItem v-if="!isEditMode" class="p-1">
    <p>
      {{ book.title }}
    </p>
    <p>
      {{ book.author }}
    </p>
    <p>
      {{ book.year }}
    </p>
    <div class="flex flex-row gap-1">
      <ActionButton
        :buttosn-type="ButtonTypesEnum.CancelButton"
        @action="removeBook"
      >
        Remove
      </ActionButton>
      <ActionButton
        :buttosn-type="ButtonTypesEnum.EditButton"
        @action="switchModes"
      >
        Edit
      </ActionButton>
    </div>
  </ListItem>
  <ListItem v-else>
    <BookInput
      input-type="text"
      :place-holder="book.title"
      v-model="bookBuffer.title"
    ></BookInput>
    <BookInput
      input-type="text"
      :place-holder="book.author"
      v-model="bookBuffer.author"
    ></BookInput>
    <BookInput
      input-type="number"
      :place-holder="book.year.toString()"
      v-model="bookBuffer.year"
    ></BookInput>
    <div class="flex flex-row gap-1">
      <ActionButton
        :buttosn-type="ButtonTypesEnum.AcceptButton"
        @action="saveChanges"
        >Save</ActionButton
      >
      <ActionButton
        :buttosn-type="ButtonTypesEnum.CancelButton"
        @action="switchModes"
        >Discard</ActionButton
      >
    </div>
  </ListItem>
</template>
