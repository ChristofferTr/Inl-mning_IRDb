const moviesList = document.getElementById('movies-list');
const modal = document.getElementById('modal');
const editText = document.getElementById('edit-movie-form');
let Id;
//let modalWindow;

function toggleMovieDetails(event) { //READ NOTE ON LINE 144
    const movieContainer = event.currentTarget;

    if (!movieContainer) {
        return;
    }

    const movieDetails = movieContainer.nextElementSibling;

    if (movieContainer.style.height === '400px') {
        movieContainer.style.height = '200px';
        movieDetails.style.display = 'none';
    } else {
        movieContainer.style.height = '400px';
        movieDetails.style.display = 'block';
    }
}

//Initial connection to the API with logic for background images, movie details and buttons
fetch('https://localhost:7194/api/movies')
    .then(response => response.json())
    .then(data => {
        data.forEach(movie => {
            const movieItem = document.createElement('div');
            movieItem.classList.add('movie');

            const movieContainer = document.createElement('div');
            movieContainer.classList.add('movie-container');
            movieContainer.style.backgroundImage = `url('images/${movie.imageUrl}')`;

            const image = new Image();
            image.src = `images/${movie.imageUrl}`;
            image.onload = () => {
                const aspectRatio = image.width / image.height;
                if (aspectRatio >= 1) {
                    movieContainer.style.backgroundSize = 'auto 100%';
                } else {
                    movieContainer.style.backgroundSize = '100% auto';
                }
            };

            const movieTitle = document.createElement('div');
            movieTitle.classList.add('movie-title');
            movieTitle.textContent = movie.title;
            movieTitle.style.position = 'relative';

            movieTitle.addEventListener('click', toggleMovieDetails);

            movieContainer.appendChild(movieTitle);

            movieContainer.addEventListener('click', toggleMovieDetails);

            const movieDetails = document.createElement('div');
            movieDetails.classList.add('movie-details');
            movieDetails.style.display = 'none';
            movieDetails.innerHTML = `
                <p><strong>Director:</strong> ${movie.director}</p>
                <p><strong>Year:</strong> ${movie.year}</p>
                <p><strong>Genre:</strong> ${movie.genre}</p>
                <p><strong>Duration:</strong> ${movie.duration} minutes</p>
                <p><strong>Rating:</strong> ${movie.rating}</p>
            `;

            const x = document.createElement('button'); //EDIT
            x.classList.add('edit-button');
            x.textContent = 'Edit';
            x.dataset.Id = movie.id; //SMALL "i" WAS THE ISSUE?
            //console.log('Edit button dataset.Id:', x.dataset.Id);

            const deleteButton = document.createElement('button'); //DELETE
            deleteButton.classList.add('delete-button');
            deleteButton.textContent = 'Delete';
            deleteButton.dataset.id = movie.id;

            x.addEventListener('click', (event) => { 
                const clickedId = event.target.dataset.Id;
                console.log('Edit button clicked');
                //Id = event.target.dataset.Id;
                console.log('Id', clickedId)
                openEditModalInSameWindow(clickedId);
            });

            function openEditModalInSameWindow(Id) {
                console.log('Fetching movie data for Id:', Id);
                fetch(`https://localhost:7194/api/movies/${Id}`)
                    .then(response => response.json())
                    .then(movieData => {
                        console.log('Movie data:', movieData);
                        openEditModal(movieData, Id);
                    })
                    .catch(error => console.error(error));
            }

            movieDetails.appendChild(x);

            movieDetails.appendChild(deleteButton);

            movieItem.appendChild(movieContainer);

            movieItem.appendChild(movieDetails);

            moviesList.appendChild(movieItem);
        });
    })
    .catch(error => console.error(error));

function populateEditForm(movieData) { //Populating the form with current movie information
    document.getElementById('edit-title').value = movieData.title;
    document.getElementById('edit-director').value = movieData.director;
    document.getElementById('edit-year').value = movieData.year;
    document.getElementById('edit-genre').value = movieData.genre;
    document.getElementById('edit-duration').value = movieData.duration;
    document.getElementById('edit-rating').value = movieData.rating;
    document.getElementById('edit-imageUrl').value = movieData.imageUrl;
}

function openEditModal(movieData, Id) {
    modal.style.display = 'block';
    populateEditForm(movieData);
    modalWindow = { Id };
}

let modalWindow;

document.getElementById('edit-movie-form-modal').addEventListener('submit', function (event) {
    event.preventDefault();

    const editedMovieData = { //New information sent to the API
        id: modalWindow.Id,
        title: document.getElementById('edit-title').value,
        director: document.getElementById('edit-director').value,
        year: parseInt(document.getElementById('edit-year').value),
        genre: document.getElementById('edit-genre').value,
        duration: parseInt(document.getElementById('edit-duration').value),
        rating: parseFloat(document.getElementById('edit-rating').value),
        imageUrl: document.getElementById('edit-imageUrl').value
    };
    //NOTE: When editing a movie it does not close the modal window, refresh the page @@
    console.log(modalWindow.Id); //Modalwindow PUT method for adding new data to the API
    fetch(`https://localhost:7194/api/movies/${modalWindow.Id}`, {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(editedMovieData),
    })
        .then(response => {
            if (response.ok) {
                return response.json(); //response.json(); ska tas bort
            } else {
                throw new Error('Failed to edit the movie.');
            }
        })
        .then(editedMovie => {
            console.log('Response from PUT request:', editedMovie);
            alert('Movie successfully edited!');
            closeEditModal();
        })
        .catch(error => console.error(error));
});



//Divider for myself during the work on this project//

document.getElementById('add-movie-form').addEventListener('submit', function (event) {
    event.preventDefault();

    const newMovie = { //Information for adding a movie
        title: document.getElementById('title').value,
        director: document.getElementById('director').value,
        year: parseInt(document.getElementById('year').value),
        genre: document.getElementById('genre').value,
        duration: parseInt(document.getElementById('duration').value),
        rating: parseFloat(document.getElementById('rating').value),
        imageUrl: document.getElementById('imageUrl').value,
    };

    fetch('https://localhost:7194/api/movies', { //POST request for adding this to the API
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
        },
        body: JSON.stringify(newMovie),
    })
        .then(response => {
            if (response.ok) {
                return response.json();
            } else {
                throw new Error('Failed to add the new movie.');
            }
        })
        .then(addedMovie => {
            createMovieItem(addedMovie);

            alert('Movie added successfully!')

            this.reset();
        })
        .catch(error => console.error(error));
});

function createMovieItem(movie) {
    const movieItem = document.createElement('div');
    movieItem.classList.add('movie');

    const movieContainer = document.createElement('div');
    movieContainer.classList.add('movie-container');
    movieContainer.style.backgroundImage = `url('images/${movie.imageUrl}')`;

    const image = new Image();
    image.src = `images/${movie.imageUrl}`;
    image.onload = () => {
        const aspectRatio = image.width / image.height;
        if (aspectRatio >= 1) {
            movieContainer.style.backgroundSize = 'auto 100%';
        } else {
            movieContainer.style.backgroundSize = '100% auto';
        }
    };

    const movieTitle = document.createElement('div');
    movieTitle.classList.add('movie-title');
    movieTitle.textContent = movie.title;
    movieTitle.style.position = 'relative';

    movieTitle.addEventListener('click', toggleMovieDetails);

    movieContainer.appendChild(movieTitle);

    movieContainer.addEventListener('click', toggleMovieDetails);

    const movieDetails = document.createElement('div');
    movieDetails.classList.add('movie-details');
    movieDetails.style.display = 'none';
    movieDetails.innerHTML = `
        <p><strong>Director:</strong> ${movie.director}</p>
        <p><strong>Year:</strong> ${movie.year}</p>
        <p><strong>Genre:</strong> ${movie.genre}</p>
        <p><strong>Duration:</strong> ${movie.duration} minutes</p>
        <p><strong>Rating:</strong> ${movie.rating}</p>
    `;
}

document.addEventListener('click', function (event) { //DELETE
    if (event.target.classList.contains('delete-button')) {
        const movieId = event.target.dataset.id;
        const confirmation = confirm('Are you sure you want to delete this movie?');
        if (confirmation) {
            deleteMovie(movieId);
        }
    }
});

function deleteMovie(movieId) { //Removing the movie from the API(DB)
    fetch(`https://localhost:7194/api/movies/${movieId}`, {
        method: 'DELETE',
    })
        .then((response) => {
            if (response.ok) {
                // Movie successfully deleted
                alert('Movie successfully deleted!');
                // Remove the movie from the UI
                const movieElement = document.querySelector(`.movie[data-id="${movieId}"]`);
                if (movieElement) {
                    movieElement.remove();
                }
            } else {
                throw new Error('Failed to delete the movie.');
            }
        })
        .catch((error) => {
            console.error(error);
        });
}

// Initial fetch and rendering of movies
fetch('https://localhost:7194/api/movies')
    .then(response => response.json())
    .then(data => {
        data.forEach(movie => {
            const movieItem = createMovieItem(movie);
            moviesList.appendChild(movieItem);
        })
    })
    .catch(error => console.error(error));

